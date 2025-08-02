using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Accounts;
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

        public async Task<IActionResult> Index(int? accountId = null)
        {
            try
            {
                var transactions = await _apiService.GetAccountTransactionsAsync();
                
                if (accountId.HasValue)
                {
                    transactions = transactions.Where(t => t.AccountId == accountId.Value);
                    ViewBag.AccountId = accountId;
                }
                
                return View(transactions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlemler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<AccountTransactionViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var transaction = await _apiService.GetAccountTransactionByIdAsync(id);
                if (transaction == null)
                {
                    TempData["Error"] = "İşlem bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(transaction);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create(int? accountId = null)
        {
            try
            {
                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;
                ViewBag.AccountId = accountId;
                
                var createViewModel = new AccountTransactionCreateViewModel();
                if (accountId.HasValue)
                {
                    createViewModel.AccountId = accountId.Value;
                }
                
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountTransactionCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateAccountTransactionAsync(createViewModel);
                    TempData["Success"] = "İşlem başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index), new { accountId = createViewModel.AccountId });
                }
                
                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;
                ViewBag.AccountId = createViewModel.AccountId;
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem oluşturulurken hata oluştu: " + ex.Message;
                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;
                ViewBag.AccountId = createViewModel.AccountId;
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var transaction = await _apiService.GetAccountTransactionByIdAsync(id);
                if (transaction == null)
                {
                    TempData["Error"] = "İşlem bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var updateViewModel = new AccountTransactionEditViewModel
                {
                    Id = transaction.Id,
                    AccountId = transaction.AccountId,
                    TransactionType = transaction.TransactionType,
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                    TransactionDate = transaction.TransactionDate,
                    ReferenceNumber = transaction.ReferenceNumber
                };

                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountTransactionEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateAccountTransactionAsync(updateViewModel);
                    TempData["Success"] = "İşlem başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index), new { accountId = updateViewModel.AccountId });
                }
                
                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem güncellenirken hata oluştu: " + ex.Message;
                var accounts = await _apiService.GetAccountsAsync();
                ViewBag.Accounts = accounts;
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var transaction = await _apiService.GetAccountTransactionByIdAsync(id);
                if (transaction == null)
                {
                    TempData["Error"] = "İşlem bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(transaction);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var transaction = await _apiService.GetAccountTransactionByIdAsync(id);
                await _apiService.DeleteAccountTransactionAsync(id);
                TempData["Success"] = "İşlem başarıyla silindi.";
                return RedirectToAction(nameof(Index), new { accountId = transaction?.AccountId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İşlem silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
