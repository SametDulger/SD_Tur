using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IApiService _apiService;

        public AccountsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _apiService.GetAsync<List<AccountDto>>("api/accounts");
            return View(accounts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var account = await _apiService.GetAsync<AccountDto>($"api/accounts/{id}/with-transactions");
            if (account == null)
                return NotFound();
            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAccountDto createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PostAsync<CreateAccountDto, AccountDto>("api/accounts", createDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var account = await _apiService.GetAsync<AccountDto>($"api/accounts/{id}");
            if (account == null)
                return NotFound();

            var updateDto = new UpdateAccountDto
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                AccountName = account.AccountName,
                AccountType = account.AccountType,
                ContactPerson = account.ContactPerson,
                Phone = account.Phone,
                Email = account.Email,
                Address = account.Address,
                CurrentBalance = account.CurrentBalance,
                Currency = account.Currency,
                IsActive = account.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateAccountDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateAccountDto, AccountDto>($"api/accounts/{updateDto.Id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var account = await _apiService.GetAsync<AccountDto>($"api/accounts/{id}");
            if (account == null)
                return NotFound();
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/accounts/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 