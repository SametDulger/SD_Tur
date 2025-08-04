using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.Currency;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetAll()
        {
            var currencies = await _currencyService.GetAllAsync();
            return Ok(currencies);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetActive()
        {
            var currencies = await _currencyService.GetActiveAsync();
            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyDto>> GetById(int id)
        {
            var currency = await _currencyService.GetByIdAsync(id);
            if (currency == null)
                return NotFound();

            return Ok(currency);
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyDto>> Create(CreateCurrencyDto createDto)
        {
            var currency = await _currencyService.CreateAsync(createDto);
            if (currency == null)
                return BadRequest("Failed to create currency");
            return CreatedAtAction(nameof(GetById), new { id = currency.Id }, currency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCurrencyDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var currency = await _currencyService.UpdateAsync(updateDto);
            if (currency == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _currencyService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
