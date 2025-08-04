using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.TourIncome;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourIncomesController : ControllerBase
    {
        private readonly ITourIncomeService _tourIncomeService;

        public TourIncomesController(ITourIncomeService tourIncomeService)
        {
            _tourIncomeService = tourIncomeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourIncomeDto>>> GetAll()
        {
            var tourIncomes = await _tourIncomeService.GetAllAsync();
            return Ok(tourIncomes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourIncomeDto>> GetById(int id)
        {
            var tourIncome = await _tourIncomeService.GetByIdAsync(id);
            if (tourIncome == null)
                return NotFound();

            return Ok(tourIncome);
        }

        [HttpGet("tourschedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<TourIncomeDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var tourIncomes = await _tourIncomeService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(tourIncomes);
        }

        [HttpPost]
        public async Task<ActionResult<TourIncomeDto>> Create(CreateTourIncomeDto createDto)
        {
            var tourIncome = await _tourIncomeService.CreateAsync(createDto);
            if (tourIncome == null)
                return BadRequest("Failed to create tour income");
            return CreatedAtAction(nameof(GetById), new { id = tourIncome.Id }, tourIncome);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourIncomeDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var tourIncome = await _tourIncomeService.UpdateAsync(updateDto);
            if (tourIncome == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tourIncomeService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 
