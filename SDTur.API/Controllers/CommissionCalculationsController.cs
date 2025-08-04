using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.CommissionCalculation;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionCalculationsController : ControllerBase
    {
        private readonly ICommissionCalculationService _commissionCalculationService;

        public CommissionCalculationsController(ICommissionCalculationService commissionCalculationService)
        {
            _commissionCalculationService = commissionCalculationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionCalculationDto>>> GetAll()
        {
            var commissionCalculations = await _commissionCalculationService.GetAllAsync();
            return Ok(commissionCalculations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommissionCalculationDto>> GetById(int id)
        {
            var commissionCalculation = await _commissionCalculationService.GetByIdAsync(id);
            if (commissionCalculation == null)
                return NotFound();
            return Ok(commissionCalculation);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<CommissionCalculationDto>>> GetByEmployee(int employeeId)
        {
            var commissionCalculations = await _commissionCalculationService.GetByEmployeeAsync(employeeId);
            return Ok(commissionCalculations);
        }

        [HttpGet("ticket/{ticketId}")]
        public async Task<ActionResult<IEnumerable<CommissionCalculationDto>>> GetByTicket(int ticketId)
        {
            var commissionCalculations = await _commissionCalculationService.GetByTicketAsync(ticketId);
            return Ok(commissionCalculations);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<CommissionCalculationDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var commissionCalculations = await _commissionCalculationService.GetByDateRangeAsync(startDate, endDate);
            return Ok(commissionCalculations);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<CommissionCalculationDto>>> GetByStatus(string status)
        {
            var commissionCalculations = await _commissionCalculationService.GetByStatusAsync(status);
            return Ok(commissionCalculations);
        }

        [HttpGet("employee/{employeeId}/total")]
        public async Task<ActionResult<decimal>> GetTotalCommissionByEmployee(int employeeId)
        {
            var totalCommission = await _commissionCalculationService.GetTotalCommissionByEmployeeAsync(employeeId);
            return Ok(totalCommission);
        }

        [HttpPost]
        public async Task<ActionResult<CommissionCalculationDto>> Create(CreateCommissionCalculationDto createDto)
        {
            var commissionCalculation = await _commissionCalculationService.CreateAsync(createDto);
            if (commissionCalculation == null)
                return BadRequest("Failed to create commission calculation");
            return CreatedAtAction(nameof(GetById), new { id = commissionCalculation.Id }, commissionCalculation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCommissionCalculationDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var commissionCalculation = await _commissionCalculationService.UpdateAsync(updateDto);
            if (commissionCalculation == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _commissionCalculationService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
