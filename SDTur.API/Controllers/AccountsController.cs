using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.Account;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetActive()
        {
            var accounts = await _accountService.GetActiveAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetById(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpGet("{id}/with-transactions")]
        public async Task<ActionResult<AccountDto>> GetWithTransactions(int id)
        {
            var account = await _accountService.GetWithTransactionsAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpGet("account-type/{accountType}")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetByAccountType(string accountType)
        {
            var accounts = await _accountService.GetByAccountTypeAsync(accountType);
            return Ok(accounts);
        }

        [HttpGet("{id}/balance")]
        public async Task<ActionResult<decimal>> GetAccountBalance(int id)
        {
            var balance = await _accountService.GetAccountBalanceAsync(id);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> Create(CreateAccountDto createDto)
        {
            try
            {
                var account = await _accountService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAccountDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var account = await _accountService.UpdateAsync(updateDto);
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
            await _accountService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
