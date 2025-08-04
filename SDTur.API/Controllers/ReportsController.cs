using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.System.Report;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAll()
        {
            var reports = await _reportService.GetAllAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetById(int id)
        {
            var report = await _reportService.GetByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpGet("report-type/{reportType}")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetByReportType(string reportType)
        {
            var reports = await _reportService.GetByReportTypeAsync(reportType);
            return Ok(reports);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reports = await _reportService.GetByDateRangeAsync(startDate, endDate);
            return Ok(reports);
        }

        [HttpGet("generated-by/{generatedBy}")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetByGeneratedBy(string generatedBy)
        {
            var reports = await _reportService.GetByGeneratedByAsync(generatedBy);
            return Ok(reports);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto>> Create(CreateReportDto createDto)
        {
            var report = await _reportService.CreateAsync(createDto);
            if (report == null)
                return BadRequest("Failed to create report");
            return CreatedAtAction(nameof(GetById), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateReportDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var report = await _reportService.UpdateAsync(updateDto);
            if (report == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reportService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("generate")]
        public async Task<ActionResult<string>> GenerateReport([FromQuery] string reportType, [FromQuery] string parameters)
        {
            var filePath = await _reportService.GenerateReportAsync(reportType, parameters);
            return Ok(filePath);
        }
    }
} 
