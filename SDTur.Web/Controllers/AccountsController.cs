using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Accounts;
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
            var accounts = await _apiService.GetAsync<List<AccountViewModel>>("api/accounts");
            return View(accounts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var account = await _apiService.GetAsync<AccountViewModel>($"api/accounts/{id}/with-transactions");
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
        public async Task<IActionResult> Create(AccountCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PostAsync<AccountCreateViewModel, AccountViewModel>("api/accounts", createViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var account = await _apiService.GetAsync<AccountViewModel>($"api/accounts/{id}");
            if (account == null)
                return NotFound();

            var updateViewModel = new AccountEditViewModel
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

            return View(updateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountEditViewModel updateViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<AccountEditViewModel, AccountViewModel>($"api/accounts/{updateViewModel.Id}", updateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(updateViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var account = await _apiService.GetAsync<AccountViewModel>($"api/accounts/{id}");
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
