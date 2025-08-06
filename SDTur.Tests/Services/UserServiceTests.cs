using Moq;
using FluentAssertions;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Application.Services.System.Implementations;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.DTOs.System.User;
using SDTur.Core.Entities.System;
using SDTur.Core.Entities.Master;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SDTur.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<UserService>> _mockLogger;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<UserService>>();
            _userService = new UserService(_mockUnitOfWork.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe", IsActive = true },
                new User { Id = 2, Username = "user2", FirstName = "Jane", LastName = "Smith", IsActive = true }
            };

            var userDtos = new List<UserDto>
            {
                new UserDto { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe" },
                new UserDto { Id = 2, Username = "user2", FirstName = "Jane", LastName = "Smith" }
            };

            _mockUnitOfWork.Setup(x => x.Users.GetAllAsync()).ReturnsAsync(users);
            _mockMapper.Setup(x => x.Map<IEnumerable<UserDto>>(users)).Returns(userDtos);

            // Act
            var result = await _userService.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(userDtos);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidId_ShouldReturnUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe", IsActive = true };
            var userDto = new UserDto { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe" };

            _mockUnitOfWork.Setup(x => x.Users.GetByIdAsync(1)).ReturnsAsync(user);
            _mockMapper.Setup(x => x.Map<UserDto>(user)).Returns(userDto);

            // Act
            var result = await _userService.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userDto);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Users.GetByIdAsync(999)).ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_WithValidData_ShouldCreateUser()
        {
            // Arrange
            var createDto = new CreateUserDto
            {
                Username = "newuser",
                Password = "Password123!",
                FirstName = "New",
                LastName = "User",
                Email = "newuser@example.com",
                RoleId = 1
            };

            var user = new User
            {
                Id = 1,
                Username = "newuser",
                FirstName = "New",
                LastName = "User",
                Email = "newuser@example.com",
                RoleId = 1
            };

            var userDto = new UserDto
            {
                Id = 1,
                Username = "newuser",
                FirstName = "New",
                LastName = "User",
                Email = "newuser@example.com"
            };

            _mockMapper.Setup(x => x.Map<User>(createDto)).Returns(user);
            _mockUnitOfWork.Setup(x => x.Users.AddAsync(user)).ReturnsAsync(user);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            _mockMapper.Setup(x => x.Map<UserDto>(user)).Returns(userDto);

            // Act
            var result = await _userService.CreateAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userDto);
            _mockUnitOfWork.Verify(x => x.Users.AddAsync(user), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WithValidData_ShouldUpdateUser()
        {
            // Arrange
            var userDto = new UserDto
            {
                Id = 1,
                Username = "user1",
                FirstName = "Updated",
                LastName = "User",
                Email = "updated@example.com"
            };

            var updatedUser = new User
            {
                Id = 1,
                Username = "user1",
                FirstName = "Updated",
                LastName = "User",
                Email = "updated@example.com"
            };

            _mockMapper.Setup(x => x.Map<User>(userDto)).Returns(updatedUser);
            _mockUnitOfWork.Setup(x => x.Users.UpdateAsync(updatedUser)).ReturnsAsync(updatedUser);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _userService.UpdateAsync(userDto);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(x => x.Users.UpdateAsync(updatedUser), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_ShouldDeleteUser()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Users.DeleteAsync(1)).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _userService.DeleteAsync(1);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(x => x.Users.DeleteAsync(1), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidId_ShouldReturnFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Users.DeleteAsync(999)).ThrowsAsync(new Exception("User not found"));

            // Act
            var result = await _userService.DeleteAsync(999);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task GetByUsernameAsync_WithValidUsername_ShouldReturnUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe", IsActive = true };
            var userDto = new UserDto { Id = 1, Username = "user1", FirstName = "John", LastName = "Doe" };

            _mockUnitOfWork.Setup(x => x.Users.GetUserByUsernameAsync("user1")).ReturnsAsync(user);
            _mockMapper.Setup(x => x.Map<UserDto>(user)).Returns(userDto);

            // Act
            var result = await _userService.GetByUsernameAsync("user1");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userDto);
        }

        [Fact]
        public async Task GetByUsernameAsync_WithInvalidUsername_ShouldReturnNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Users.GetUserByUsernameAsync("nonexistent")).ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetByUsernameAsync("nonexistent");

            // Assert
            result.Should().BeNull();
        }
    }
} 