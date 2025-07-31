using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.Bus;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusesController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusDto>>> GetBuses()
        {
            var buses = await _busService.GetAllBusesAsync();
            return Ok(buses);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<BusDto>>> GetActiveBuses()
        {
            var buses = await _busService.GetActiveBusesAsync();
            return Ok(buses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusDto>> GetBus(int id)
        {
            var bus = await _busService.GetBusByIdAsync(id);
            if (bus == null)
                return NotFound();

            return Ok(bus);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<BusDto>>> GetAvailableBuses()
        {
            var buses = await _busService.GetAvailableBusesAsync();
            return Ok(buses);
        }

        [HttpPost]
        public async Task<ActionResult<BusDto>> CreateBus(CreateBusDto createBusDto)
        {
            var bus = await _busService.CreateBusAsync(createBusDto);
            return CreatedAtAction(nameof(GetBus), new { id = bus.Id }, bus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBus(int id, UpdateBusDto updateBusDto)
        {
            if (id != updateBusDto.Id)
                return BadRequest();

            var bus = await _busService.UpdateBusAsync(updateBusDto);
            if (bus == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            await _busService.DeleteBusAsync(id);
            return NoContent();
        }
    }
} 