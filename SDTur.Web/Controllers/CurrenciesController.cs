using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly IApiService _apiService;

        public CurrenciesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var currencies = await _apiService.GetAsync<List<CurrencyDto>>("api/currencies");
            return View(currencies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyDto>($"api/currencies/{id}");
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
        public async Task<IActionResult> Create([Bind("Code,Name,Symbol,IsActive")] CreateCurrencyDto createCurrencyDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateCurrencyDto, CurrencyDto>("api/currencies", createCurrencyDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createCurrencyDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyDto>($"api/currencies/{id}");
            if (currency == null)
                return NotFound();

            var updateDto = new UpdateCurrencyDto
            {
                Id = currency.Id,
                Name = currency.Name,
                Code = currency.Code,
                Symbol = currency.Symbol,
                IsActive = currency.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCurrencyDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateCurrencyDto, CurrencyDto>($"api/currencies/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currency = await _apiService.GetAsync<CurrencyDto>($"api/currencies/{id}");
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