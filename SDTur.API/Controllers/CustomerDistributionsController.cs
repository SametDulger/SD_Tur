using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.CustomerDistribution;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerDistributionsController : ControllerBase
    {
        private readonly ICustomerDistributionService _customerDistributionService;

        public CustomerDistributionsController(ICustomerDistributionService customerDistributionService)
        {
            _customerDistributionService = customerDistributionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetAll()
        {
            var customerDistributions = await _customerDistributionService.GetAllAsync();
            return Ok(customerDistributions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDistributionDto>> GetById(int id)
        {
            var customerDistribution = await _customerDistributionService.GetByIdAsync(id);
            if (customerDistribution == null)
                return NotFound();
            return Ok(customerDistribution);
        }

        [HttpGet("tour-schedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var customerDistributions = await _customerDistributionService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(customerDistributions);
        }

        [HttpGet("bus/{busId}")]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetByBus(int busId)
        {
            var customerDistributions = await _customerDistributionService.GetByBusAsync(busId);
            return Ok(customerDistributions);
        }

        [HttpGet("ticket/{ticketId}")]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetByTicket(int ticketId)
        {
            var customerDistributions = await _customerDistributionService.GetByTicketAsync(ticketId);
            return Ok(customerDistributions);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var customerDistributions = await _customerDistributionService.GetByDateRangeAsync(startDate, endDate);
            return Ok(customerDistributions);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<CustomerDistributionDto>>> GetByStatus(string status)
        {
            var customerDistributions = await _customerDistributionService.GetByStatusAsync(status);
            return Ok(customerDistributions);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDistributionDto>> Create(CreateCustomerDistributionDto createDto)
        {
            var result = await _customerDistributionService.CreateAsync(createDto);
            if (result == null)
                return BadRequest("Failed to create customer distribution");
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerDistributionDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var result = await _customerDistributionService.UpdateAsync(updateDto);
            if (result == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerDistributionService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
