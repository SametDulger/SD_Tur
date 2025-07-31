using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.Cash;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers.Financial
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashController : ControllerBase
    {
        private readonly ICashService _cashService;

        public CashController(ICashService cashService)
        {
            _cashService = cashService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashDto>>> GetAll()
        {
            var cashTransactions = await _cashService.GetAllAsync();
            return Ok(cashTransactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CashDto>> GetById(int id)
        {
            var cashTransaction = await _cashService.GetByIdAsync(id);
            if (cashTransaction == null)
                return NotFound();
            return Ok(cashTransaction);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<CashDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var cashTransactions = await _cashService.GetByDateRangeAsync(startDate, endDate);
            return Ok(cashTransactions);
        }

        [HttpGet("transaction-type/{transactionType}")]
        public async Task<ActionResult<IEnumerable<CashDto>>> GetByTransactionType(string transactionType)
        {
            var cashTransactions = await _cashService.GetByTransactionTypeAsync(transactionType);
            return Ok(cashTransactions);
        }

        [HttpGet("balance")]
        public async Task<ActionResult<decimal>> GetTotalBalance([FromQuery] DateTime date, [FromQuery] string currency)
        {
            var balance = await _cashService.GetTotalBalanceAsync(date, currency);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<ActionResult<CashDto>> Create(CreateCashDto createDto)
        {
            try
            {
                var cashTransaction = await _cashService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = cashTransaction.Id }, cashTransaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCashDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            try
            {
                var cashTransaction = await _cashService.UpdateAsync(updateDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cashService.DeleteAsync(id);
            return NoContent();
        }
    }
} 