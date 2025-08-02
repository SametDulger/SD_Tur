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
            try
            {
                var accounts = await _apiService.GetAccountsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Currencies = currencies;
                return View(accounts);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesaplar yüklenirken hata oluştu: " + ex.Message;
                return View(new List<AccountViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var account = await _apiService.GetAccountByIdAsync(id);
                if (account == null)
                {
                    TempData["Error"] = "Hesap bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(account);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(new AccountCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateAccountAsync(createViewModel);
                    TempData["Success"] = "Hesap başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap oluşturulurken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var account = await _apiService.GetAccountByIdAsync(id);
                if (account == null)
                {
                    TempData["Error"] = "Hesap bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

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
                    CurrencyId = account.CurrencyId,
                    IsActive = account.IsActive,
                    Description = account.Description,
                    CreatedDate = account.CreatedDate,
                    UpdatedDate = account.UpdatedDate
                };

                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateAccountAsync(updateViewModel);
                    TempData["Success"] = "Hesap başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap güncellenirken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var account = await _apiService.GetAccountByIdAsync(id);
                if (account == null)
                {
                    TempData["Error"] = "Hesap bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(account);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteAccountAsync(id);
                TempData["Success"] = "Hesap başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hesap silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
