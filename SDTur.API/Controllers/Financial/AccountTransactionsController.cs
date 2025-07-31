using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.AccountTransaction;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers.Financial
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountTransactionsController : ControllerBase
    {
        private readonly IAccountTransactionService _accountTransactionService;

        public AccountTransactionsController(IAccountTransactionService accountTransactionService)
        {
            _accountTransactionService = accountTransactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTransactionDto>>> GetAll()
        {
            var accountTransactions = await _accountTransactionService.GetAllAsync();
            return Ok(accountTransactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTransactionDto>> GetById(int id)
        {
            var accountTransaction = await _accountTransactionService.GetByIdAsync(id);
            if (accountTransaction == null)
                return NotFound();

            return Ok(accountTransaction);
        }

        [HttpGet("passcompany/{passCompanyId}")]
        public async Task<ActionResult<IEnumerable<AccountTransactionDto>>> GetByPassCompany(int passCompanyId)
        {
            var accountTransactions = await _accountTransactionService.GetByPassCompanyAsync(passCompanyId);
            return Ok(accountTransactions);
        }

        [HttpGet("tourschedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<AccountTransactionDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var accountTransactions = await _accountTransactionService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(accountTransactions);
        }

        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<AccountTransactionDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var accountTransactions = await _accountTransactionService.GetByDateRangeAsync(startDate, endDate);
            return Ok(accountTransactions);
        }

        [HttpPost]
        public async Task<ActionResult<AccountTransactionDto>> Create(CreateAccountTransactionDto createDto)
        {
            try
            {
                var accountTransaction = await _accountTransactionService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = accountTransaction.Id }, accountTransaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AccountTransactionDto>> Update(int id, UpdateAccountTransactionDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var accountTransaction = await _accountTransactionService.UpdateAsync(updateDto);
                return Ok(accountTransaction);
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
                await _accountTransactionService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 