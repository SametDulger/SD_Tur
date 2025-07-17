using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusAssignmentsController : ControllerBase
    {
        private readonly IBusAssignmentService _busAssignmentService;

        public BusAssignmentsController(IBusAssignmentService busAssignmentService)
        {
            _busAssignmentService = busAssignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusAssignmentDto>>> GetAll()
        {
            var busAssignments = await _busAssignmentService.GetAllAsync();
            return Ok(busAssignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusAssignmentDto>> GetById(int id)
        {
            var busAssignment = await _busAssignmentService.GetByIdAsync(id);
            if (busAssignment == null)
                return NotFound();
            return Ok(busAssignment);
        }

        [HttpGet("tour-schedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<BusAssignmentDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var busAssignments = await _busAssignmentService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(busAssignments);
        }

        [HttpGet("bus/{busId}")]
        public async Task<ActionResult<IEnumerable<BusAssignmentDto>>> GetByBus(int busId)
        {
            var busAssignments = await _busAssignmentService.GetByBusAsync(busId);
            return Ok(busAssignments);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<BusAssignmentDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var busAssignments = await _busAssignmentService.GetByDateRangeAsync(startDate, endDate);
            return Ok(busAssignments);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<BusAssignmentDto>>> GetByStatus(string status)
        {
            var busAssignments = await _busAssignmentService.GetByStatusAsync(status);
            return Ok(busAssignments);
        }

        [HttpPost]
        public async Task<ActionResult<BusAssignmentDto>> Create(CreateBusAssignmentDto createDto)
        {
            try
            {
                var busAssignment = await _busAssignmentService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = busAssignment.Id }, busAssignment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BusAssignmentDto>> Update(int id, UpdateBusAssignmentDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var busAssignment = await _busAssignmentService.UpdateAsync(updateDto);
                return Ok(busAssignment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _busAssignmentService.DeleteAsync(id);
            return NoContent();
        }
    }
} 