using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Financial;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class TourExpensesController : Controller
    {
        private readonly IApiService _apiService;

        public TourExpensesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourExpenses = await _apiService.GetAsync<List<TourExpenseViewModel>>("api/tourexpenses");
            return View(tourExpenses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourExpense = await _apiService.GetAsync<TourExpenseViewModel>($"api/tourexpenses/{id}");
            if (tourExpense == null)
                return NotFound();

            return View(tourExpense);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,Category,Amount,Currency,Description,ExpenseDate")] TourExpenseCreateViewModel createTourExpenseViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<TourExpenseCreateViewModel, TourExpenseViewModel>("api/tourexpenses", createTourExpenseViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(createTourExpenseViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourExpense = await _apiService.GetAsync<TourExpenseViewModel>($"api/tourexpenses/{id}");
            if (tourExpense == null)
                return NotFound();

            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;

            var updateDto = new TourExpenseEditViewModel
            {
                Id = tourExpense.Id,
                TourScheduleId = tourExpense.TourScheduleId,
                Category = tourExpense.Category,
                Description = tourExpense.Description,
                Amount = tourExpense.Amount,
                Currency = tourExpense.Currency,
                ExpenseDate = tourExpense.ExpenseDate,
                IsActive = tourExpense.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,Category,Description,Amount,Currency,ExpenseDate,IsActive")] TourExpenseEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<TourExpenseEditViewModel, TourExpenseViewModel>($"api/tourexpenses/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourExpense = await _apiService.GetAsync<TourExpenseViewModel>($"api/tourexpenses/{id}");
            if (tourExpense == null)
                return NotFound();

            return View(tourExpense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tourexpenses/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
