using Moq;
using FluentAssertions;
using SDTur.Application.Services.System.Implementations;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Entities.System;
using SDTur.Application.DTOs.System.Auth;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SDTur.Core.Interfaces.System;

namespace SDTur.Tests.Services
{
    public class TokenServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IRefreshTokenRepository> _mockRefreshTokenRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<ILogger<TokenService>> _mockLogger;
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockLogger = new Mock<ILogger<TokenService>>();
            
            // Mock JWT configuration
            var jwtSettings = new Mock<IConfigurationSection>();
            jwtSettings.Setup(x => x["SecretKey"]).Returns("your-super-secret-key-with-at-least-32-characters");
            jwtSettings.Setup(x => x["Issuer"]).Returns("SDTur");
            jwtSettings.Setup(x => x["Audience"]).Returns("SDTurUsers");
            jwtSettings.Setup(x => x["ExpirationInMinutes"]).Returns("60");
            


            _mockConfiguration.Setup(x => x.GetSection("JwtSettings")).Returns(jwtSettings.Object);
            
            // Mock environment variable
            Environment.SetEnvironmentVariable("JWT_SECRET_KEY", "your-super-secret-key-with-at-least-32-characters");
            
            _tokenService = new TokenService(_mockConfiguration.Object, _mockRefreshTokenRepository.Object, _mockUserRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GenerateAccessTokenAsync_WithValidParameters_ShouldReturnToken()
        {
            // Arrange
            var userId = 1;
            var username = "testuser";
            var role = "User";

            // Act
            var result = await _tokenService.GenerateAccessTokenAsync(userId, username, role);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().Contain(".");
        }

        [Fact]
        public async Task GenerateRefreshTokenAsync_ShouldReturnToken()
        {
            // Act
            var result = await _tokenService.GenerateRefreshTokenAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ValidateRefreshTokenAsync_WithValidToken_ShouldReturnTrue()
        {
            // Arrange
            var refreshToken = "valid-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);

            // Act
            var result = await _tokenService.ValidateRefreshTokenAsync(refreshToken);

            // Assert
            result.Should().BeTrue();
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task ValidateRefreshTokenAsync_WithInvalidToken_ShouldReturnFalse()
        {
            // Arrange
            var refreshToken = "invalid-refresh-token";
            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync((RefreshToken?)null);

            // Act
            var result = await _tokenService.ValidateRefreshTokenAsync(refreshToken);

            // Assert
            result.Should().BeFalse();
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task ValidateRefreshTokenAsync_WithExpiredToken_ShouldReturnFalse()
        {
            // Arrange
            var refreshToken = "expired-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(-1), // Expired
                IsRevoked = false
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);

            // Act
            var result = await _tokenService.ValidateRefreshTokenAsync(refreshToken);

            // Assert
            result.Should().BeFalse();
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task ValidateRefreshTokenAsync_WithRevokedToken_ShouldReturnFalse()
        {
            // Arrange
            var refreshToken = "revoked-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = true // Revoked
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);

            // Act
            var result = await _tokenService.ValidateRefreshTokenAsync(refreshToken);

            // Assert
            result.Should().BeFalse();
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task RevokeRefreshTokenAsync_WithValidToken_ShouldCompleteSuccessfully()
        {
            // Arrange
            var refreshToken = "valid-refresh-token";
            var reason = "User logout";

            // Act
            await _tokenService.RevokeRefreshTokenAsync(refreshToken, reason);

            // Assert
            _mockRefreshTokenRepository.Verify(x => x.RevokeTokenAsync(refreshToken, reason), Times.Once);
        }

        [Fact]
        public async Task GetUserActiveTokensAsync_WithValidUserId_ShouldReturnTokens()
        {
            // Arrange
            var userId = 1;
            var refreshTokens = new List<RefreshToken> 
            { 
                new RefreshToken { Token = "token1" },
                new RefreshToken { Token = "token2" },
                new RefreshToken { Token = "token3" }
            };

            _mockRefreshTokenRepository.Setup(x => x.GetActiveTokensByUserIdAsync(userId)).ReturnsAsync(refreshTokens);

            // Act
            var result = await _tokenService.GetUserActiveTokensAsync(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.Should().Contain("token1");
            result.Should().Contain("token2");
            result.Should().Contain("token3");
            _mockRefreshTokenRepository.Verify(x => x.GetActiveTokensByUserIdAsync(userId), Times.Once);
        }

        [Fact]
        public async Task RefreshTokenAsync_WithValidToken_ShouldReturnNewTokens()
        {
            // Arrange
            var refreshToken = "valid-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
            var user = new User 
            { 
                Id = 1, 
                Username = "testuser", 
                IsActive = true,
                RoleId = 1,
                Role = new Role { Id = 1, Name = "User" }
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);
            _mockUserRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(user);
            _mockRefreshTokenRepository.Setup(x => x.RevokeTokenAsync(refreshToken, "Token refreshed")).Returns(Task.CompletedTask);

            // Act
            var result = await _tokenService.RefreshTokenAsync(refreshToken);

            // Assert
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeEmpty();
            result.RefreshToken.Should().NotBeEmpty();
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
            _mockUserRepository.Verify(x => x.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task RefreshTokenAsync_WithInvalidToken_ShouldThrowException()
        {
            // Arrange
            var refreshToken = "invalid-refresh-token";
            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync((RefreshToken?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _tokenService.RefreshTokenAsync(refreshToken));
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task RefreshTokenAsync_WithExpiredToken_ShouldThrowException()
        {
            // Arrange
            var refreshToken = "expired-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(-1), // Expired
                IsRevoked = false
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _tokenService.RefreshTokenAsync(refreshToken));
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }

        [Fact]
        public async Task RefreshTokenAsync_WithRevokedToken_ShouldThrowException()
        {
            // Arrange
            var refreshToken = "revoked-refresh-token";
            var refreshTokenEntity = new RefreshToken 
            { 
                Id = 1, 
                Token = refreshToken, 
                UserId = 1, 
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = true // Revoked
            };

            _mockRefreshTokenRepository.Setup(x => x.GetByTokenAsync(refreshToken)).ReturnsAsync(refreshTokenEntity);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _tokenService.RefreshTokenAsync(refreshToken));
            _mockRefreshTokenRepository.Verify(x => x.GetByTokenAsync(refreshToken), Times.Once);
        }
    }
} 