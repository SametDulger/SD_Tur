using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceSchedulesController : ControllerBase
    {
        private readonly IServiceScheduleService _serviceScheduleService;

        public ServiceSchedulesController(IServiceScheduleService serviceScheduleService)
        {
            _serviceScheduleService = serviceScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceScheduleDto>>> GetAll()
        {
            var serviceSchedules = await _serviceScheduleService.GetAllAsync();
            return Ok(serviceSchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceScheduleDto>> GetById(int id)
        {
            var serviceSchedule = await _serviceScheduleService.GetByIdAsync(id);
            if (serviceSchedule == null)
                return NotFound();

            return Ok(serviceSchedule);
        }

        [HttpGet("tour/{tourId}")]
        public async Task<ActionResult<IEnumerable<ServiceScheduleDto>>> GetByTour(int tourId)
        {
            var serviceSchedules = await _serviceScheduleService.GetByTourAsync(tourId);
            return Ok(serviceSchedules);
        }

        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<IEnumerable<ServiceScheduleDto>>> GetByRegion(int regionId)
        {
            var serviceSchedules = await _serviceScheduleService.GetByRegionAsync(regionId);
            return Ok(serviceSchedules);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<ServiceScheduleDto>>> GetByDate(DateTime date)
        {
            var serviceSchedules = await _serviceScheduleService.GetByDateAsync(date);
            return Ok(serviceSchedules);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceScheduleDto>> Create(CreateServiceScheduleDto createDto)
        {
            try
            {
                var serviceSchedule = await _serviceScheduleService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = serviceSchedule.Id }, serviceSchedule);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceScheduleDto>> Update(int id, UpdateServiceScheduleDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var serviceSchedule = await _serviceScheduleService.UpdateAsync(updateDto);
                return Ok(serviceSchedule);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _serviceScheduleService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 