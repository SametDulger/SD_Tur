using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.FinancialReport;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialReportsController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportsController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialReportDto>>> GetAll()
        {
            var financialReports = await _financialReportService.GetAllAsync();
            return Ok(financialReports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialReportDto>> GetById(int id)
        {
            var financialReport = await _financialReportService.GetByIdAsync(id);
            if (financialReport == null)
                return NotFound();
            return Ok(financialReport);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<FinancialReportDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var financialReports = await _financialReportService.GetByDateRangeAsync(startDate, endDate);
            return Ok(financialReports);
        }

        [HttpGet("report-type/{reportType}")]
        public async Task<ActionResult<IEnumerable<FinancialReportDto>>> GetByReportType(string reportType)
        {
            var financialReports = await _financialReportService.GetByReportTypeAsync(reportType);
            return Ok(financialReports);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<FinancialReportDto>>> GetByStatus(string status)
        {
            var financialReports = await _financialReportService.GetByStatusAsync(status);
            return Ok(financialReports);
        }

        [HttpGet("report-type/{reportType}/latest")]
        public async Task<ActionResult<FinancialReportDto>> GetLatestByType(string reportType)
        {
            var financialReport = await _financialReportService.GetLatestByTypeAsync(reportType);
            if (financialReport == null)
                return NotFound();
            return Ok(financialReport);
        }

        [HttpPost]
        public async Task<ActionResult<FinancialReportDto>> Create(CreateFinancialReportDto createDto)
        {
            try
            {
                var financialReport = await _financialReportService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = financialReport.Id }, financialReport);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FinancialReportDto>> Update(int id, UpdateFinancialReportDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var financialReport = await _financialReportService.UpdateAsync(updateDto);
                return Ok(financialReport);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _financialReportService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
