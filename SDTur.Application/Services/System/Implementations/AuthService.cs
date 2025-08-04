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
            var user = await _userService.GetByUsernameAsync(loginDto.Username);
            
            if (user == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }

            if (!user.IsActive)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Hesabınız aktif değil"
                };
            }

            // Şifre doğrulama (gerçek uygulamada hash karşılaştırması yapılır)
            if (user.Password != loginDto.Password) // TODO: Hash karşılaştırması yapılacak
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }

            var token = await GenerateTokenAsync(user);
            var refreshToken = await GenerateRefreshTokenAsync();

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

        public async Task<string> GenerateTokenAsync(UserDto user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("BranchId", user.BranchId?.ToString() ?? ""),
                new Claim("EmployeeId", user.EmployeeId?.ToString() ?? "")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["ExpirationInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
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
                var secretKey = jwtSettings["SecretKey"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"],
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
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return false;

            // Mevcut şifre kontrolü
            if (user.Password != changePasswordDto.CurrentPassword) // TODO: Hash karşılaştırması
                return false;

            // Yeni şifre güncelleme
            user.Password = changePasswordDto.NewPassword; // TODO: Hash'leme
            await _userService.UpdateAsync(user.Id, new UpdateUserDto
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                EmployeeId = user.EmployeeId,
                BranchId = user.BranchId,
                Role = user.Role,
                IsActive = user.IsActive
            });

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
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                BranchName = user.BranchName,
                EmployeeName = user.EmployeeName,
                IsActive = user.IsActive
            };
        }
    }
} 