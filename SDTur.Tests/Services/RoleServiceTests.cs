using Moq;
using FluentAssertions;
using SDTur.Application.Services.System.Implementations;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Entities.System;
using SDTur.Application.DTOs.System.User;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SDTur.Tests.Services
{
    public class RoleServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<RoleService>> _mockLogger;
        private readonly RoleService _roleService;

        public RoleServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<RoleService>>();
            _roleService = new RoleService(_mockUnitOfWork.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllRoles()
        {
            // Arrange
            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin", Description = "Administrator", IsActive = true },
                new Role { Id = 2, Name = "Manager", Description = "Manager", IsActive = true },
                new Role { Id = 3, Name = "User", Description = "Regular User", IsActive = true }
            };

            var roleDtos = new List<RoleDto>
            {
                new RoleDto { Id = 1, Name = "Admin", Description = "Administrator", IsActive = true },
                new RoleDto { Id = 2, Name = "Manager", Description = "Manager", IsActive = true },
                new RoleDto { Id = 3, Name = "User", Description = "Regular User", IsActive = true }
            };

            _mockUnitOfWork.Setup(x => x.Roles.GetAllAsync()).ReturnsAsync(roles);
            _mockMapper.Setup(x => x.Map<IEnumerable<RoleDto>>(roles)).Returns(roleDtos);

            // Act
            var result = await _roleService.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.Should().BeEquivalentTo(roleDtos);
            _mockUnitOfWork.Verify(x => x.Roles.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidId_ShouldReturnRole()
        {
            // Arrange
            var role = new Role { Id = 1, Name = "Admin", Description = "Administrator", IsActive = true };
            var roleDto = new RoleDto { Id = 1, Name = "Admin", Description = "Administrator", IsActive = true };

            _mockUnitOfWork.Setup(x => x.Roles.GetByIdAsync(1)).ReturnsAsync(role);
            _mockMapper.Setup(x => x.Map<RoleDto>(role)).Returns(roleDto);

            // Act
            var result = await _roleService.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(roleDto);
            _mockUnitOfWork.Verify(x => x.Roles.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Roles.GetByIdAsync(0)).ReturnsAsync((Role?)null);

            // Act
            var result = await _roleService.GetByIdAsync(0);

            // Assert
            result.Should().BeNull();
            // Note: Service doesn't call repository for invalid ID, so we don't verify the call
        }

        [Fact]
        public async Task CreateAsync_WithValidData_ShouldCreateRole()
        {
            // Arrange
            var createDto = new CreateRoleDto { Name = "TestRole", Description = "Test Description", IsActive = true };
            var role = new Role { Id = 1, Name = "TestRole", Description = "Test Description", IsActive = true };
            var roleDto = new RoleDto { Id = 1, Name = "TestRole", Description = "Test Description", IsActive = true };

            _mockMapper.Setup(x => x.Map<Role>(createDto)).Returns(role);
            _mockUnitOfWork.Setup(x => x.Roles.AddAsync(role)).ReturnsAsync(role);
            _mockMapper.Setup(x => x.Map<RoleDto>(role)).Returns(roleDto);

            // Act
            var result = await _roleService.CreateAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(roleDto);
            _mockUnitOfWork.Verify(x => x.Roles.AddAsync(role), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WithValidData_ShouldUpdateRole()
        {
            // Arrange
            var roleDto = new RoleDto { Id = 1, Name = "UpdatedRole", Description = "Updated Description", IsActive = true };
            var role = new Role { Id = 1, Name = "UpdatedRole", Description = "Updated Description", IsActive = true };

            _mockMapper.Setup(x => x.Map<Role>(roleDto)).Returns(role);
            _mockUnitOfWork.Setup(x => x.Roles.UpdateAsync(role)).ReturnsAsync(role);

            // Act
            var result = await _roleService.UpdateAsync(roleDto);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(x => x.Roles.UpdateAsync(role), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_ShouldDeleteRole()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Roles.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _roleService.DeleteAsync(1);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(x => x.Roles.DeleteAsync(1), Times.Once);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidId_ShouldReturnFalse()
        {
            // Arrange
            // No setup needed as service validates ID > 0 and returns false

            // Act
            var result = await _roleService.DeleteAsync(0);

            // Assert
            result.Should().BeFalse(); // Service validates ID > 0 and returns false for invalid ID
            _mockUnitOfWork.Verify(x => x.Roles.DeleteAsync(It.IsAny<int>()), Times.Never);
        }
    }
} 