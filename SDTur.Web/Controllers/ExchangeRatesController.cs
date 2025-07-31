using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class ExchangeRatesController : Controller
    {
        private readonly IApiService _apiService;

        public ExchangeRatesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var exchangeRates = await _apiService.GetAsync<List<ExchangeRateViewModel>>("api/exchangerates");
            return View(exchangeRates);
        }

        public async Task<IActionResult> Details(int id)
        {
            var exchangeRate = await _apiService.GetAsync<ExchangeRateViewModel>($"api/exchangerates/{id}");
            if (exchangeRate == null)
                return NotFound();

            return View(exchangeRate);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FromCurrency,ToCurrency,Rate,RateDate,Date")] ExchangeRateCreateViewModel createExchangeRateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<ExchangeRateCreateViewModel, ExchangeRateViewModel>("api/exchangerates", createExchangeRateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createExchangeRateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exchangeRate = await _apiService.GetAsync<ExchangeRateViewModel>($"api/exchangerates/{id}");
            if (exchangeRate == null)
                return NotFound();

            var updateDto = new ExchangeRateEditViewModel
            {
                Id = exchangeRate.Id,
                FromCurrency = exchangeRate.FromCurrency,
                ToCurrency = exchangeRate.ToCurrency,
                Rate = exchangeRate.Rate,
                RateDate = exchangeRate.RateDate,
                Date = exchangeRate.Date,
                IsActive = exchangeRate.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FromCurrency,ToCurrency,Rate,RateDate,Date,IsActive")] ExchangeRateEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<ExchangeRateEditViewModel, ExchangeRateViewModel>($"api/exchangerates/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exchangeRate = await _apiService.GetAsync<ExchangeRateViewModel>($"api/exchangerates/{id}");
            if (exchangeRate == null)
                return NotFound();

            return View(exchangeRate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/exchangerates/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
