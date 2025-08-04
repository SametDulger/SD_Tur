using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.ExchangeRate;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExchangeRateDto>>> GetAll()
        {
            var exchangeRates = await _exchangeRateService.GetAllAsync();
            return Ok(exchangeRates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExchangeRateDto>> GetById(int id)
        {
            var exchangeRate = await _exchangeRateService.GetByIdAsync(id);
            if (exchangeRate == null)
                return NotFound();

            return Ok(exchangeRate);
        }

        [HttpGet("latest/{fromCurrency}/{toCurrency}")]
        public async Task<ActionResult<ExchangeRateDto>> GetLatestRate(string fromCurrency, string toCurrency)
        {
            var exchangeRate = await _exchangeRateService.GetLatestRateAsync(fromCurrency, toCurrency);
            if (exchangeRate == null)
                return NotFound();

            return Ok(exchangeRate);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<ExchangeRateDto>>> GetByDate(DateTime date)
        {
            var exchangeRates = await _exchangeRateService.GetRatesByDateAsync(date);
            return Ok(exchangeRates);
        }

        [HttpGet("currency/{currency}")]
        public async Task<ActionResult<IEnumerable<ExchangeRateDto>>> GetByCurrency(string currency)
        {
            var exchangeRates = await _exchangeRateService.GetRatesByCurrencyAsync(currency);
            return Ok(exchangeRates);
        }

        [HttpPost]
        public async Task<ActionResult<ExchangeRateDto>> Create(CreateExchangeRateDto createDto)
        {
            var exchangeRate = await _exchangeRateService.CreateAsync(createDto);
            if (exchangeRate == null)
                return BadRequest("Failed to create exchange rate");
            return CreatedAtAction(nameof(GetById), new { id = exchangeRate.Id }, exchangeRate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateExchangeRateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var exchangeRate = await _exchangeRateService.UpdateAsync(updateDto);
            if (exchangeRate == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exchangeRateService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
