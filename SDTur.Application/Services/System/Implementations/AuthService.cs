using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.DTOs.System.User;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SDTur.Application.Services.System.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserService userService, IConfiguration configuration, IUserRepository userRepository)
        {
            _userService = userService;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            // Debug için log ekleyelim
            Console.WriteLine($"Login attempt for username: {loginDto.Username}");
            Console.WriteLine($"Input password: {loginDto.Password}");
            
            try
            {
                var user = await _userService.GetByUsernameAsync(loginDto.Username);
                Console.WriteLine($"UserService.GetByUsernameAsync completed");
                
                if (user == null)
                {
                    Console.WriteLine($"User not found: {loginDto.Username}");
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Kullanıcı adı veya şifre hatalı"
                    };
                }
            
            Console.WriteLine($"User found: {user.Username}, Password: {user.Password}, Input Password: {loginDto.Password}");

            if (!user.IsActive)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Hesabınız aktif değil"
                };
            }

            // Şifre doğrulama - SeedData'da plain text şifreler var
            Console.WriteLine($"Password comparison: DB='{user.Password}' vs Input='{loginDto.Password}'");
            if (user.Password != loginDto.Password)
            {
                Console.WriteLine("Password mismatch!");
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }
            
            Console.WriteLine("Password match successful!");

            var token = await GenerateTokenAsync(user);
            var refreshToken = await GenerateRefreshTokenAsync();

            Console.WriteLine("Login successful! Generating response...");

            return new LoginResponseDto
            {
                Success = true,
                Token = token,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpirationInMinutes"])),
                User = new UserInfoDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Role = user.Role,
                    BranchName = user.BranchName,
                    EmployeeName = user.EmployeeName,
                    IsActive = user.IsActive
                },
                Message = "Giriş başarılı"
            };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in LoginAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Giriş sırasında bir hata oluştu"
                };
            }
        }

        public async Task<string> GenerateTokenAsync(UserDto user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? "";
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

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"] ?? "";
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            Console.WriteLine($"AuthService.ChangePasswordAsync called with userId: {userId}");
            
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                Console.WriteLine($"User not found for userId: {userId}");
                return false;
            }

            Console.WriteLine($"User found: {user.Username}, Current DB Password: {user.Password}");
            Console.WriteLine($"Input Current Password: {changePasswordDto.CurrentPassword}");

            // Mevcut şifre kontrolü - SeedData'da plain text şifreler var
            if (user.Password != changePasswordDto.CurrentPassword)
            {
                Console.WriteLine("Current password mismatch!");
                return false;
            }

            Console.WriteLine("Current password match successful!");

            // Yeni şifre güncelleme - Şimdilik plain text olarak kaydediyoruz
            user.Password = changePasswordDto.NewPassword;
            Console.WriteLine($"New password set: {user.Password}");
            
            await _userService.UpdateAsync(new UpdateUserDto
            {
                Id = user.Id,
                Username = user.Username ?? "",
                Password = user.Password ?? "",
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email ?? "",
                Phone = user.Phone ?? "",
                EmployeeId = user.EmployeeId,
                BranchId = user.BranchId,
                Role = user.Role ?? "",
                IsActive = user.IsActive
            });

            Console.WriteLine("Password update successful!");
            return true;
        }

        public async Task<bool> LogoutAsync(string token)
        {
            // Token blacklist'e eklenebilir
            // Şimdilik sadece true döndürüyoruz
            return true;
        }

        public async Task<UserInfoDto> GetCurrentUserAsync(int userId)
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