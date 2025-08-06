using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;

namespace SDTur.Application.Services.System.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TokenService> _logger;

        public TokenService(
            IConfiguration configuration,
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            ILogger<TokenService> logger)
        {
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public Task<string> GenerateAccessTokenAsync(int userId, string username, string role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? 
                           jwtSettings["SecretKey"] ?? 
                           throw new InvalidOperationException("JWT SecretKey is not configured");

            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim("sub", userId.ToString()),
                new Claim("nameid", userId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["ExpirationInMinutes"] ?? "480")),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        public Task<string> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        public async Task<RefreshTokenResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
            if (token == null || token.IsRevoked || token.ExpiresAt < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Invalid or expired refresh token");
            }

            var user = await _userRepository.GetByIdAsync(token.UserId);
            if (user == null || !user.IsActive)
            {
                throw new InvalidOperationException("User not found or inactive");
            }

            // Revoke the current refresh token
            await _refreshTokenRepository.RevokeTokenAsync(refreshToken, "Token refreshed");

            // Generate new tokens
            var newAccessToken = await GenerateAccessTokenAsync(user.Id, user.Username, user.Role?.Name ?? "User");
            var newRefreshToken = await GenerateRefreshTokenAsync();

            // Save new refresh token
            var newToken = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7), // 7 days
                IsRevoked = false
            };

            await _refreshTokenRepository.AddAsync(newToken);

            return new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JwtSettings")["ExpirationInMinutes"] ?? "480")),
                TokenType = "Bearer"
            };
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken, string reason = "User logout")
        {
            await _refreshTokenRepository.RevokeTokenAsync(refreshToken, reason);
        }

        public async Task<bool> ValidateRefreshTokenAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
            return token != null && !token.IsRevoked && token.ExpiresAt > DateTime.UtcNow;
        }

        public async Task<IEnumerable<string>> GetUserActiveTokensAsync(int userId)
        {
            var tokens = await _refreshTokenRepository.GetActiveTokensByUserIdAsync(userId);
            return tokens.Select(t => t.Token);
        }
    }
} 