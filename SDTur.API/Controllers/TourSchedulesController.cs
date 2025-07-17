using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourSchedulesController : ControllerBase
    {
        private readonly ITourScheduleService _tourScheduleService;

        public TourSchedulesController(ITourScheduleService tourScheduleService)
        {
            _tourScheduleService = tourScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourScheduleDto>>> GetTourSchedules()
        {
            var tourSchedules = await _tourScheduleService.GetAllTourSchedulesAsync();
            return Ok(tourSchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourScheduleDto>> GetTourSchedule(int id)
        {
            var tourSchedule = await _tourScheduleService.GetTourScheduleByIdAsync(id);
            if (tourSchedule == null)
                return NotFound();

            return Ok(tourSchedule);
        }

        [HttpGet("tour/{tourId}")]
        public async Task<ActionResult<IEnumerable<TourScheduleDto>>> GetTourSchedulesByTour(int tourId)
        {
            var tourSchedules = await _tourScheduleService.GetTourSchedulesByTourAsync(tourId);
            return Ok(tourSchedules);
        }

        [HttpGet("date/{date:datetime}")]
        public async Task<ActionResult<IEnumerable<TourScheduleDto>>> GetTourSchedulesByDate(DateTime date)
        {
            var tourSchedules = await _tourScheduleService.GetTourSchedulesByDateAsync(date);
            return Ok(tourSchedules);
        }

        [HttpPost]
        public async Task<ActionResult<TourScheduleDto>> CreateTourSchedule(CreateTourScheduleDto createTourScheduleDto)
        {
            var tourSchedule = await _tourScheduleService.CreateTourScheduleAsync(createTourScheduleDto);
            return CreatedAtAction(nameof(GetTourSchedule), new { id = tourSchedule.Id }, tourSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTourSchedule(int id, UpdateTourScheduleDto updateTourScheduleDto)
        {
            if (id != updateTourScheduleDto.Id)
                return BadRequest();

            var tourSchedule = await _tourScheduleService.UpdateTourScheduleAsync(updateTourScheduleDto);
            if (tourSchedule == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourSchedule(int id)
        {
            await _tourScheduleService.DeleteTourScheduleAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> CompleteTourSchedule(int id)
        {
            await _tourScheduleService.CompleteTourScheduleAsync(id);
            return NoContent();
        }
    }
} 