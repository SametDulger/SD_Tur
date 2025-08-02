using Microsoft.AspNetCore.Mvc;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Application.DTOs.Tour.Tour;
using System.Linq;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly ITourScheduleService _tourScheduleService;

        public TourController(
            ITourService tourService,
            ITourScheduleService tourScheduleService)
        {
            _tourService = tourService;
            _tourScheduleService = tourScheduleService;
        }

        [HttpGet("tours")]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours(
            [FromQuery] string? tourTypeId,
            [FromQuery] string? status,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            try
            {
                var allTours = await _tourService.GetAllToursAsync();
                var filteredTours = allTours.AsQueryable();

                // Apply filters
                if (!string.IsNullOrEmpty(tourTypeId))
                {
                    // Filter by tour type (you can modify this based on your actual tour type logic)
                    filteredTours = filteredTours.Where(t => t.Destination.Contains(tourTypeId));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    // Filter by status (using IsActive as a proxy for status)
                    if (status == "Active")
                        filteredTours = filteredTours.Where(t => t.IsActive);
                    else if (status == "Inactive")
                        filteredTours = filteredTours.Where(t => !t.IsActive);
                }

                if (startDate.HasValue)
                {
                    filteredTours = filteredTours.Where(t => t.CreatedDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    filteredTours = filteredTours.Where(t => t.CreatedDate <= endDate.Value);
                }

                return Ok(filteredTours.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Turlar yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("tours/statistics")]
        public async Task<ActionResult<object>> GetTourStatistics(
            [FromQuery] string? tourTypeId,
            [FromQuery] string? status,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            try
            {
                var allTours = await _tourService.GetAllToursAsync();
                var filteredTours = allTours.AsQueryable();

                // Apply same filters as GetTours
                if (!string.IsNullOrEmpty(tourTypeId))
                {
                    filteredTours = filteredTours.Where(t => t.Destination.Contains(tourTypeId));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    // Filter by status (using IsActive as a proxy for status)
                    if (status == "Active")
                        filteredTours = filteredTours.Where(t => t.IsActive);
                    else if (status == "Inactive")
                        filteredTours = filteredTours.Where(t => !t.IsActive);
                }

                if (startDate.HasValue)
                {
                    filteredTours = filteredTours.Where(t => t.CreatedDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    filteredTours = filteredTours.Where(t => t.CreatedDate <= endDate.Value);
                }

                var toursList = filteredTours.ToList();

                var statistics = new
                {
                    totalTours = toursList.Count,
                    activeTours = toursList.Count(t => t.IsActive),
                    inactiveTours = toursList.Count(t => !t.IsActive),
                    totalRevenue = toursList.Sum(t => t.Price),
                    averageDuration = toursList.Any() ? toursList.Average(t => t.Duration) : 0
                };

                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Tur istatistikleri yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<object>>> GetUpcomingTours()
        {
            try
            {
                var allSchedules = await _tourScheduleService.GetAllTourSchedulesAsync();
                var upcomingSchedules = allSchedules
                    .Where(s => s.TourDate >= DateTime.Now.Date && !s.IsCompleted && !s.IsCancelled)
                    .OrderBy(s => s.TourDate)
                    .Take(6);

                var upcomingTours = upcomingSchedules.Select(schedule => new
                {
                    id = schedule.Id,
                    name = schedule.TourName,
                    destination = "", // Not available in DTO
                    startDate = schedule.TourDate.ToString("dd.MM.yyyy"),
                    duration = 0, // Not available in DTO
                    totalSeats = schedule.MaxCapacity,
                    bookedSeats = schedule.CurrentCapacity,
                    capacityPercentage = schedule.MaxCapacity > 0 ? Math.Round((double)schedule.CurrentCapacity / schedule.MaxCapacity * 100, 1) : 0,
                    status = schedule.TourDate.Date == DateTime.Now.Date ? "Bugün" : 
                             schedule.TourDate.Date <= DateTime.Now.Date.AddDays(7) ? "Yakında" : "Aktif"
                });

                return Ok(upcomingTours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Yaklaşan turlar yüklenirken hata oluştu", details = ex.Message });
            }
        }
    }
} 