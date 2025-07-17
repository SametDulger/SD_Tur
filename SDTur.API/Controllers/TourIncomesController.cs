using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

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
            try
            {
                var tourIncome = await _tourIncomeService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = tourIncome.Id }, tourIncome);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TourIncomeDto>> Update(int id, UpdateTourIncomeDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var tourIncome = await _tourIncomeService.UpdateAsync(updateDto);
                return Ok(tourIncome);
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