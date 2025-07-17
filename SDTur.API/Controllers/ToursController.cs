using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours()
        {
            var tours = await _tourService.GetAllToursAsync();
            return Ok(tours);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetActiveTours()
        {
            var tours = await _tourService.GetActiveToursAsync();
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour(int id)
        {
            var tour = await _tourService.GetTourByIdAsync(id);
            if (tour == null)
                return NotFound();

            return Ok(tour);
        }

        [HttpPost]
        public async Task<ActionResult<TourDto>> CreateTour(CreateTourDto createTourDto)
        {
            var tour = await _tourService.CreateTourAsync(createTourDto);
            return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTour(int id, UpdateTourDto updateTourDto)
        {
            if (id != updateTourDto.Id)
                return BadRequest();

            var tour = await _tourService.UpdateTourAsync(updateTourDto);
            if (tour == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            await _tourService.DeleteTourAsync(id);
            return NoContent();
        }
    }
} 