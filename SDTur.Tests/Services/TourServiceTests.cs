using Moq;
using FluentAssertions;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Application.Services.Tour.Implementations;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.DTOs.Tour.Tour;
using SDTur.Core.Entities.Tour;
using AutoMapper;

namespace SDTur.Tests.Services
{
    public class TourServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITourService _tourService;

        public TourServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _tourService = new TourService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllToursAsync_ShouldReturnAllTours()
        {
            // Arrange
            var tours = new List<Tour>
            {
                new Tour { Id = 1, Name = "Test Tour 1", IsActive = true },
                new Tour { Id = 2, Name = "Test Tour 2", IsActive = true }
            };

            var tourDtos = new List<TourDto>
            {
                new TourDto { Id = 1, Name = "Test Tour 1" },
                new TourDto { Id = 2, Name = "Test Tour 2" }
            };

            _mockUnitOfWork.Setup(x => x.Tours.GetAllAsync()).ReturnsAsync(tours);
            _mockMapper.Setup(x => x.Map<IEnumerable<TourDto>>(tours)).Returns(tourDtos);

            // Act
            var result = await _tourService.GetAllToursAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(tourDtos);
        }

        [Fact]
        public async Task GetTourByIdAsync_WithValidId_ShouldReturnTour()
        {
            // Arrange
            var tour = new Tour { Id = 1, Name = "Test Tour", IsActive = true };
            var tourDto = new TourDto { Id = 1, Name = "Test Tour" };

            _mockUnitOfWork.Setup(x => x.Tours.GetByIdAsync(1)).ReturnsAsync(tour);
            _mockMapper.Setup(x => x.Map<TourDto>(tour)).Returns(tourDto);

            // Act
            var result = await _tourService.GetTourByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(tourDto);
        }

        [Fact]
        public async Task GetTourByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.Tours.GetByIdAsync(999)).ReturnsAsync((Tour?)null);

            // Act
            var result = await _tourService.GetTourByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_WithValidData_ShouldCreateTour()
        {
            // Arrange
            var createDto = new CreateTourDto
            {
                Name = "New Tour",
                Description = "Desc",
                Duration = 3,
                Destination = "Test Destination",
                BasePrice = 100,
                Price = 120,
                TourTypeId = 1,
                Currency = "TRY",
                IsActive = true
            };

            var tour = new Tour
            {
                Id = 1,
                Name = "New Tour",
                Description = "Desc",
                Duration = 3,
                Destination = "Test Destination"
            };

            var tourDto = new TourDto
            {
                Id = 1,
                Name = "New Tour",
                Description = "Desc",
                Duration = 3,
                Destination = "Test Destination"
            };

            _mockMapper.Setup(x => x.Map<Tour>(createDto)).Returns(tour);
            _mockUnitOfWork.Setup(x => x.Tours.AddAsync(tour)).ReturnsAsync(tour);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            _mockMapper.Setup(x => x.Map<TourDto>(tour)).Returns(tourDto);

            // Act
            var result = await _tourService.CreateAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(tourDto);
            _mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
} 