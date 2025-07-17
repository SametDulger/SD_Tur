using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class AccountTransactionsController : Controller
    {
        private readonly IApiService _apiService;

        public AccountTransactionsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var accountTransactions = await _apiService.GetAsync<List<AccountTransactionDto>>("api/accounttransactions");
            return View(accountTransactions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var accountTransaction = await _apiService.GetAsync<AccountTransactionDto>($"api/accounttransactions/{id}");
            if (accountTransaction == null)
                return NotFound();

            return View(accountTransaction);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,TourScheduleId,TicketId,PassCompanyId,Amount,Currency,TransactionType,Description,Reference,TransactionDate")] CreateAccountTransactionDto createAccountTransactionDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateAccountTransactionDto, AccountTransactionDto>("api/accounttransactions", createAccountTransactionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createAccountTransactionDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var accountTransaction = await _apiService.GetAsync<AccountTransactionDto>($"api/accounttransactions/{id}");
            if (accountTransaction == null)
                return NotFound();

            var updateDto = new UpdateAccountTransactionDto
            {
                Id = accountTransaction.Id,
                AccountId = accountTransaction.AccountId,
                TourScheduleId = accountTransaction.TourScheduleId,
                TicketId = accountTransaction.TicketId,
                PassCompanyId = accountTransaction.PassCompanyId,
                TransactionType = accountTransaction.TransactionType,
                Amount = accountTransaction.Amount,
                Currency = accountTransaction.Currency,
                TransactionDate = accountTransaction.TransactionDate,
                Description = accountTransaction.Description,
                Reference = accountTransaction.Reference,
                IsActive = accountTransaction.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAccountTransactionDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateAccountTransactionDto, AccountTransactionDto>($"api/accounttransactions/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var accountTransaction = await _apiService.GetAsync<AccountTransactionDto>($"api/accounttransactions/{id}");
            if (accountTransaction == null)
                return NotFound();

            return View(accountTransaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/accounttransactions/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 