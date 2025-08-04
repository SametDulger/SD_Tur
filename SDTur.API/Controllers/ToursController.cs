using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.Tour;
using SDTur.Application.Services.Tour.Interfaces;

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
        public async Task<ActionResult<TourDto>> Create(CreateTourDto createDto)
        {
            var tour = await _tourService.CreateAsync(createDto);
            if (tour == null)
                return BadRequest("Failed to create tour");
            return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var tour = await _tourService.UpdateAsync(updateDto);
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
