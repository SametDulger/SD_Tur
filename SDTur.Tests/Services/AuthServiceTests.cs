using Moq;
using FluentAssertions;
using SDTur.Application.Services.System.Implementations;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Entities.System;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.DTOs.System.User;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using BCrypt.Net;

namespace SDTur.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<ILogger<AuthService>> _mockLogger;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<AuthService>>();
            
                                    // Mock configuration for JWT settings
                        _mockConfiguration.Setup(x => x["JwtSettings:ExpirationInMinutes"]).Returns("60");
                        _mockConfiguration.Setup(x => x["JwtSettings:SecretKey"]).Returns("your-super-secret-key-with-at-least-32-characters");
                        _mockConfiguration.Setup(x => x["JwtSettings:Issuer"]).Returns("SDTur");
                        _mockConfiguration.Setup(x => x["JwtSettings:Audience"]).Returns("SDTurUsers");
                        
                        // Mock JWT settings section
                        var jwtSettings = new Mock<IConfigurationSection>();
                        jwtSettings.Setup(x => x["SecretKey"]).Returns("your-super-secret-key-with-at-least-32-characters");
                        jwtSettings.Setup(x => x["Issuer"]).Returns("SDTur");
                        jwtSettings.Setup(x => x["Audience"]).Returns("SDTurUsers");
                        jwtSettings.Setup(x => x["ExpirationInMinutes"]).Returns("60");
                        _mockConfiguration.Setup(x => x.GetSection("JwtSettings")).Returns(jwtSettings.Object);
            
            _authService = new AuthService(_mockUserService.Object, _mockConfiguration.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task LoginAsync_WithValidCredentials_ShouldReturnSuccessResponse()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "Test123!" };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("Test123!"),
                IsActive = true,
                Role = "User"
            };

            _mockUserService.Setup(x => x.GetByUsernameAsync("testuser")).ReturnsAsync(userDto);

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.UserInfo.Should().NotBeNull();
            result.UserInfo.Username.Should().Be("testuser");
            _mockUserService.Verify(x => x.GetByUsernameAsync("testuser"), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_WithInvalidUsername_ShouldReturnFailureResponse()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "invaliduser", Password = "Test123!" };
            _mockUserService.Setup(x => x.GetByUsernameAsync("invaliduser")).ReturnsAsync((UserDto?)null);

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Kullanıcı adı veya şifre hatalı");
            _mockUserService.Verify(x => x.GetByUsernameAsync("invaliduser"), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_WithInvalidPassword_ShouldReturnFailureResponse()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "WrongPassword" };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("Test123!"),
                IsActive = true
            };

            _mockUserService.Setup(x => x.GetByUsernameAsync("testuser")).ReturnsAsync(userDto);

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Kullanıcı adı veya şifre hatalı");
            _mockUserService.Verify(x => x.GetByUsernameAsync("testuser"), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_WithInactiveUser_ShouldReturnFailureResponse()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "Test123!" };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("Test123!"),
                IsActive = false
            };

            _mockUserService.Setup(x => x.GetByUsernameAsync("testuser")).ReturnsAsync(userDto);

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Hesabınız aktif değil");
            _mockUserService.Verify(x => x.GetByUsernameAsync("testuser"), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_WithEmptyCredentials_ShouldReturnFailureResponse()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "", Password = "" };

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Kullanıcı adı ve şifre gereklidir");
        }

        [Fact]
        public async Task ChangePasswordAsync_WithValidData_ShouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var changePasswordDto = new ChangePasswordDto 
            { 
                CurrentPassword = "OldPassword123!", 
                NewPassword = "NewPassword123!",
                ConfirmPassword = "NewPassword123!"
            };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("OldPassword123!"),
                IsActive = true
            };

            _mockUserService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(userDto);
            _mockUserService.Setup(x => x.UpdateAsync(It.IsAny<UserDto>())).ReturnsAsync(true);

            // Act
            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);

            // Assert
            result.Should().BeTrue();
            _mockUserService.Verify(x => x.GetByIdAsync(1), Times.Once);
            _mockUserService.Verify(x => x.UpdateAsync(It.IsAny<UserDto>()), Times.Once);
        }

        [Fact]
        public async Task ChangePasswordAsync_WithInvalidUserId_ShouldReturnFalse()
        {
            // Arrange
            var userId = 999;
            var changePasswordDto = new ChangePasswordDto 
            { 
                CurrentPassword = "OldPassword123!", 
                NewPassword = "NewPassword123!",
                ConfirmPassword = "NewPassword123!"
            };

            _mockUserService.Setup(x => x.GetByIdAsync(999)).ReturnsAsync((UserDto?)null);

            // Act
            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);

            // Assert
            result.Should().BeFalse();
            _mockUserService.Verify(x => x.GetByIdAsync(999), Times.Once);
        }

        [Fact]
        public async Task ChangePasswordAsync_WithInvalidCurrentPassword_ShouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var changePasswordDto = new ChangePasswordDto 
            { 
                CurrentPassword = "WrongPassword", 
                NewPassword = "NewPassword123!",
                ConfirmPassword = "NewPassword123!"
            };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("OldPassword123!"),
                IsActive = true
            };

            _mockUserService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(userDto);

            // Act
            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);

            // Assert
            result.Should().BeFalse();
            _mockUserService.Verify(x => x.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task ChangePasswordAsync_WithMismatchedPasswords_ShouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var changePasswordDto = new ChangePasswordDto 
            { 
                CurrentPassword = "OldPassword123!", 
                NewPassword = "NewPassword123!",
                ConfirmPassword = "DifferentPassword123!"
            };
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                Password = BCrypt.Net.BCrypt.HashPassword("OldPassword123!"),
                IsActive = true
            };

            _mockUserService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(userDto);

            // Act
            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);

            // Assert
            result.Should().BeFalse();
            _mockUserService.Verify(x => x.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetCurrentUserAsync_WithValidUserId_ShouldReturnUserInfo()
        {
            // Arrange
            var userId = 1;
            var userDto = new UserDto 
            { 
                Id = 1, 
                Username = "testuser", 
                FirstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                IsActive = true,
                Role = "User"
            };

            _mockUserService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(userDto);

            // Act
            var result = await _authService.GetCurrentUserAsync(userId);

            // Assert
            result.Should().NotBeNull();
            result!.Username.Should().Be("testuser");
            result.FirstName.Should().Be("Test");
            result.LastName.Should().Be("User");
            _mockUserService.Verify(x => x.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetCurrentUserAsync_WithInvalidUserId_ShouldReturnNull()
        {
            // Arrange
            var userId = 999;
            _mockUserService.Setup(x => x.GetByIdAsync(999)).ReturnsAsync((UserDto?)null);

            // Act
            var result = await _authService.GetCurrentUserAsync(userId);

            // Assert
            result.Should().BeNull();
            _mockUserService.Verify(x => x.GetByIdAsync(999), Times.Once);
        }
    }
} 