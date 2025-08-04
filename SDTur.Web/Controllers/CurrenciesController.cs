using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class CurrenciesController : Controller
    {
        private readonly IApiService _apiService;

        public CurrenciesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            return View(currencies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyViewModel>($"api/currencies/{id}");
            if (currency == null)
                return NotFound();

            return View(currency);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Symbol,IsActive")] CurrencyCreateViewModel createCurrencyViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CurrencyCreateViewModel, CurrencyViewModel>("api/currencies", createCurrencyViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createCurrencyViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyViewModel>($"api/currencies/{id}");
            if (currency == null)
                return NotFound();

            var updateDto = new CurrencyEditViewModel
            {
                Id = currency.Id,
                Name = currency.Name,
                Code = currency.Code,
                Symbol = currency.Symbol
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CurrencyEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<CurrencyEditViewModel, CurrencyViewModel>($"api/currencies/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyViewModel>($"api/currencies/{id}");
            if (currency == null)
                return NotFound();

            return View(currency);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/currencies/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
