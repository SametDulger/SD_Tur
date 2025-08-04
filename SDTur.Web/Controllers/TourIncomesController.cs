using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Financial;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class TourIncomesController : Controller
    {
        private readonly IApiService _apiService;

        public TourIncomesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourIncomes = await _apiService.GetAsync<List<TourIncomeViewModel>>("api/tourincomes");
            return View(tourIncomes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeViewModel>($"api/tourincomes/{id}");
            if (tourIncome == null)
                return NotFound();

            return View(tourIncome);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,Category,Amount,Currency,Description,IncomeDate")] TourIncomeCreateViewModel createTourIncomeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<TourIncomeCreateViewModel, TourIncomeViewModel>("api/tourincomes", createTourIncomeViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(createTourIncomeViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeViewModel>($"api/tourincomes/{id}");
            if (tourIncome == null)
                return NotFound();

            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;

            var updateDto = new TourIncomeEditViewModel
            {
                Id = tourIncome.Id,
                TourScheduleId = tourIncome.TourScheduleId,
                Category = tourIncome.Category,
                Description = tourIncome.Description,
                Amount = tourIncome.Amount,
                Currency = tourIncome.Currency,
                IncomeDate = tourIncome.IncomeDate,
                IsActive = tourIncome.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,Category,Description,Amount,Currency,IncomeDate,IsActive")] TourIncomeEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<TourIncomeEditViewModel, TourIncomeViewModel>($"api/tourincomes/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeViewModel>($"api/tourincomes/{id}");
            if (tourIncome == null)
                return NotFound();

            return View(tourIncome);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tourincomes/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
