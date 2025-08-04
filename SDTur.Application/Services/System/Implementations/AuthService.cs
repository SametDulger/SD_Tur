using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.DTOs.System.User;
using SDTur.Application.Services.System.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using BCrypt.Net;

namespace SDTur.Application.Services.System.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserService userService, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _userService = userService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            try
            {
                _logger.LogInformation("Login attempt for username: {Username}", loginDto.Username);

                if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
                {
                    _logger.LogWarning("Login attempt with empty username or password");
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Kullanıcı adı ve şifre gereklidir."
                    };
                }

                var user = await _userService.GetByUsernameAsync(loginDto.Username);
                if (user == null)
                {
                    _logger.LogWarning("Login attempt with non-existent username: {Username}", loginDto.Username);
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Kullanıcı adı veya şifre hatalı."
                    };
                }

                if (!user.IsActive)
                {
                    _logger.LogWarning("Login attempt for inactive user: {Username}", loginDto.Username);
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Hesabınız aktif değil."
                    };
                }

                // BCrypt ile şifre karşılaştırması
                bool passwordValid = false;
                try
                {
                    passwordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password ?? "");
                }
                catch (BCrypt.Net.SaltParseException)
                {
                    // Eski plain text şifreler için fallback (geçici)
                    passwordValid = user.Password == loginDto.Password;
                }

                if (!passwordValid)
                {
                    _logger.LogWarning("Login attempt with wrong password for user: {Username}", loginDto.Username);
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Kullanıcı adı veya şifre hatalı."
                    };
                }

                _logger.LogInformation("Login successful for user: {Username}", loginDto.Username);

                var userInfo = new UserInfoDto
                {
                    Id = user.Id,
                    Username = user.Username ?? "",
                    FirstName = user.FirstName ?? "",
                    LastName = user.LastName ?? "",
                    Email = user.Email ?? "",
                    Phone = user.Phone ?? "",
                    Role = user.Role ?? "",
                    BranchName = user.BranchName ?? "",
                    EmployeeName = user.EmployeeName ?? "",
                    IsActive = user.IsActive
                };

                var token = await GenerateTokenAsync(user);
                var refreshToken = await GenerateRefreshTokenAsync();
                var expiresAt = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpirationInMinutes"] ?? "60"));

                return new LoginResponseDto
                {
                    Success = true,
                    Message = "Giriş başarılı.",
                    UserInfo = userInfo,
                    Token = token,
                    RefreshToken = refreshToken,
                    ExpiresAt = expiresAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during login for user: {Username}", loginDto.Username);
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Giriş sırasında bir hata oluştu."
                };
            }
        }

        public Task<string> GenerateTokenAsync(UserDto user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? "";
            
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT SecretKey is not configured");
            }
            
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? ""),
                new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
                new Claim(ClaimTypes.Surname, user.LastName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? ""),
                new Claim("BranchId", user.BranchId?.ToString() ?? ""),
                new Claim("EmployeeId", user.EmployeeId?.ToString() ?? "")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["ExpirationInMinutes"] ?? "60")),
                Issuer = jwtSettings["Issuer"] ?? "",
                Audience = jwtSettings["Audience"] ?? "",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        public Task<string> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        public Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"] ?? "";
                
                if (string.IsNullOrEmpty(secretKey))
                {
                    return Task.FromResult(false);
                }
                
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"] ?? "",
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"] ?? "",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public async Task<ChangePasswordResponseDto> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            try
            {
                _logger.LogInformation("Password change attempt for user ID: {UserId}", userId);

                if (userId <= 0)
                {
                    _logger.LogWarning("Invalid user ID for password change: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Geçersiz kullanıcı."
                    };
                }

                var user = await _userService.GetByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogWarning("User not found for password change: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı."
                    };
                }

                if (!user.IsActive)
                {
                    _logger.LogWarning("Password change attempt for inactive user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Hesabınız aktif değil."
                    };
                }

                // Mevcut şifre kontrolü (BCrypt ile)
                bool currentPasswordValid = false;
                try
                {
                    currentPasswordValid = BCrypt.Net.BCrypt.Verify(changePasswordDto.CurrentPassword, user.Password ?? "");
                }
                catch (BCrypt.Net.SaltParseException)
                {
                    // Eski plain text şifreler için fallback (geçici)
                    currentPasswordValid = user.Password == changePasswordDto.CurrentPassword;
                }

                if (!currentPasswordValid)
                {
                    _logger.LogWarning("Password change attempt with wrong current password for user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Mevcut şifre hatalı."
                    };
                }

                // Yeni şifre validasyonu
                if (string.IsNullOrWhiteSpace(changePasswordDto.NewPassword) || changePasswordDto.NewPassword.Length < 6)
                {
                    _logger.LogWarning("Password change attempt with invalid new password for user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Yeni şifre en az 6 karakter olmalıdır."
                    };
                }

                if (changePasswordDto.NewPassword != changePasswordDto.ConfirmPassword)
                {
                    _logger.LogWarning("Password change attempt with mismatched passwords for user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Yeni şifreler eşleşmiyor."
                    };
                }

                // Yeni şifreyi BCrypt ile hash'le
                user.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
                var updateResult = await _userService.UpdateAsync(user);

                if (updateResult)
                {
                    _logger.LogInformation("Password change successful for user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = true,
                        Message = "Şifre başarıyla değiştirildi."
                    };
                }
                else
                {
                    _logger.LogError("Failed to update password for user: {UserId}", userId);
                    return new ChangePasswordResponseDto
                    {
                        Success = false,
                        Message = "Şifre güncellenirken bir hata oluştu."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during password change for user: {UserId}", userId);
                return new ChangePasswordResponseDto
                {
                    Success = false,
                    Message = "Şifre değiştirme sırasında bir hata oluştu."
                };
            }
        }

        public Task<bool> LogoutAsync(string token)
        {
            // Token blacklist'e eklenebilir
            // Şimdilik sadece true döndürüyoruz
            return Task.FromResult(true);
        }

        public async Task<UserInfoDto?> GetCurrentUserAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return null;

            return new UserInfoDto
            {
                Id = user.Id,
                Username = user.Username ?? "",
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email ?? "",
                Phone = user.Phone ?? "",
                Role = user.Role ?? "",
                BranchName = user.BranchName ?? "",
                EmployeeName = user.EmployeeName ?? "",
                IsActive = user.IsActive
            };
        }
    }
} 