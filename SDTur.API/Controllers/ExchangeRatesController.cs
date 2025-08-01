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
            try
            {
                var exchangeRate = await _exchangeRateService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = exchangeRate.Id }, exchangeRate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExchangeRateDto>> Update(int id, UpdateExchangeRateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var exchangeRate = await _exchangeRateService.UpdateAsync(updateDto);
                return Ok(exchangeRate);
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
                await _exchangeRateService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 
