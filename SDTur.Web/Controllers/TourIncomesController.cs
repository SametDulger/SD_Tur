using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class TourIncomesController : Controller
    {
        private readonly IApiService _apiService;

        public TourIncomesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourIncomes = await _apiService.GetAsync<List<TourIncomeDto>>("api/tourincomes");
            return View(tourIncomes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeDto>($"api/tourincomes/{id}");
            if (tourIncome == null)
                return NotFound();

            return View(tourIncome);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,Category,Amount,Currency,Description,IncomeDate")] CreateTourIncomeDto createTourIncomeDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateTourIncomeDto, TourIncomeDto>("api/tourincomes", createTourIncomeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createTourIncomeDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeDto>($"api/tourincomes/{id}");
            if (tourIncome == null)
                return NotFound();

            var updateDto = new UpdateTourIncomeDto
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,Category,Description,Amount,Currency,IncomeDate,IsActive")] UpdateTourIncomeDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateTourIncomeDto, TourIncomeDto>($"api/tourincomes/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourIncome = await _apiService.GetAsync<TourIncomeDto>($"api/tourincomes/{id}");
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