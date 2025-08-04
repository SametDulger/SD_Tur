using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class ExchangeRatesController : Controller
    {
        private readonly IApiService _apiService;

        public ExchangeRatesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var exchangeRates = await _apiService.GetExchangeRatesAsync();
                return View(exchangeRates);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kurları yüklenirken hata oluştu: " + ex.Message;
                return View(new List<ExchangeRateViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var exchangeRate = await _apiService.GetExchangeRateByIdAsync(id);
                if (exchangeRate == null)
                {
                    TempData["Error"] = "Döviz kuru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(exchangeRate);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(new ExchangeRateCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExchangeRateCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateExchangeRateAsync(createViewModel);
                    TempData["Success"] = "Döviz kuru başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru oluşturulurken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var exchangeRate = await _apiService.GetExchangeRateByIdAsync(id);
                if (exchangeRate == null)
                {
                    TempData["Error"] = "Döviz kuru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;

                var updateViewModel = new ExchangeRateEditViewModel
                {
                    Id = exchangeRate.Id,
                    FromCurrency = exchangeRate.FromCurrency,
                    ToCurrency = exchangeRate.ToCurrency,
                    Rate = exchangeRate.Rate,
                    RateDate = exchangeRate.RateDate,
                    Date = exchangeRate.Date,
                    IsActive = exchangeRate.IsActive
                };

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExchangeRateEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateExchangeRateAsync(updateViewModel);
                    TempData["Success"] = "Döviz kuru başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru güncellenirken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                ViewBag.Currencies = currencies;
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var exchangeRate = await _apiService.GetExchangeRateByIdAsync(id);
                if (exchangeRate == null)
                {
                    TempData["Error"] = "Döviz kuru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(exchangeRate);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteExchangeRateAsync(id);
                TempData["Success"] = "Döviz kuru başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Döviz kuru silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
