using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.TourExpense;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourExpensesController : ControllerBase
    {
        private readonly ITourExpenseService _tourExpenseService;

        public TourExpensesController(ITourExpenseService tourExpenseService)
        {
            _tourExpenseService = tourExpenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourExpenseDto>>> GetAll()
        {
            var tourExpenses = await _tourExpenseService.GetAllAsync();
            return Ok(tourExpenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourExpenseDto>> GetById(int id)
        {
            var tourExpense = await _tourExpenseService.GetByIdAsync(id);
            if (tourExpense == null)
                return NotFound();

            return Ok(tourExpense);
        }

        [HttpGet("tourschedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<TourExpenseDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var tourExpenses = await _tourExpenseService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(tourExpenses);
        }

        [HttpPost]
        public async Task<ActionResult<TourExpenseDto>> Create(CreateTourExpenseDto createDto)
        {
            var tourExpense = await _tourExpenseService.CreateAsync(createDto);
            if (tourExpense == null)
                return BadRequest("Failed to create tour expense");
            return CreatedAtAction(nameof(GetById), new { id = tourExpense.Id }, tourExpense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourExpenseDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var tourExpense = await _tourExpenseService.UpdateAsync(updateDto);
            if (tourExpense == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourExpenseService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
