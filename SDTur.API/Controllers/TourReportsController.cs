using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.TourReport;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourReportsController : ControllerBase
    {
        private readonly ITourReportService _tourReportService;

        public TourReportsController(ITourReportService tourReportService)
        {
            _tourReportService = tourReportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourReportDto>>> GetAll()
        {
            var tourReports = await _tourReportService.GetAllAsync();
            return Ok(tourReports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourReportDto>> GetById(int id)
        {
            var tourReport = await _tourReportService.GetByIdAsync(id);
            if (tourReport == null)
                return NotFound();
            return Ok(tourReport);
        }

        [HttpGet("tour/{tourId}")]
        public async Task<ActionResult<IEnumerable<TourReportDto>>> GetByTour(int tourId)
        {
            var tourReports = await _tourReportService.GetByTourAsync(tourId);
            return Ok(tourReports);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<TourReportDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var tourReports = await _tourReportService.GetByDateRangeAsync(startDate, endDate);
            return Ok(tourReports);
        }

        [HttpGet("report-type/{reportType}")]
        public async Task<ActionResult<IEnumerable<TourReportDto>>> GetByReportType(string reportType)
        {
            var tourReports = await _tourReportService.GetByReportTypeAsync(reportType);
            return Ok(tourReports);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<TourReportDto>>> GetByStatus(string status)
        {
            var tourReports = await _tourReportService.GetByStatusAsync(status);
            return Ok(tourReports);
        }

        [HttpGet("tour/{tourId}/latest")]
        public async Task<ActionResult<TourReportDto>> GetLatestByTour(int tourId)
        {
            var tourReport = await _tourReportService.GetLatestByTourAsync(tourId);
            if (tourReport == null)
                return NotFound();
            return Ok(tourReport);
        }

        [HttpPost]
        public async Task<ActionResult<TourReportDto>> Create(CreateTourReportDto createDto)
        {
            try
            {
                var tourReport = await _tourReportService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = tourReport.Id }, tourReport);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TourReportDto>> Update(int id, UpdateTourReportDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var tourReport = await _tourReportService.UpdateAsync(updateDto);
                return Ok(tourReport);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tourReportService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
