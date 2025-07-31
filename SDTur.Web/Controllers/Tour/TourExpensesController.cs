using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Financial;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Tour
{
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,Category,Amount,Currency,Description,ExpenseDate")] CreateTourExpenseViewModel createTourExpenseViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateTourExpenseViewModel, TourExpenseViewModel>("api/tourexpenses", createTourExpenseViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createTourExpenseViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourExpense = await _apiService.GetAsync<TourExpenseViewModel>($"api/tourexpenses/{id}");
            if (tourExpense == null)
                return NotFound();

            var updateDto = new UpdateTourExpenseViewModel
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,Category,Description,Amount,Currency,ExpenseDate,IsActive")] UpdateTourExpenseViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateTourExpenseViewModel, TourExpenseViewModel>($"api/tourexpenses/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
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