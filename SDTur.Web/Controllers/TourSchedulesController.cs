using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class TourSchedulesController : Controller
    {
        private readonly IApiService _apiService;

        public TourSchedulesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleViewModel>>("api/tourschedules");
            return View(tourSchedules);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourSchedule = await _apiService.GetAsync<TourScheduleViewModel>($"api/tourschedules/{id}");
            if (tourSchedule == null)
                return NotFound();

            return View(tourSchedule);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,TourDate,IsCompleted,IsCancelled,TotalIncome,TotalExpense,NetProfit,Notes")] TourScheduleCreateViewModel createDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<TourScheduleCreateViewModel, TourScheduleViewModel>("api/tourschedules", createDto);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourSchedule = await _apiService.GetAsync<TourScheduleViewModel>($"api/tourschedules/{id}");
            if (tourSchedule == null)
                return NotFound();

            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;

            var updateDto = new TourScheduleEditViewModel
            {
                Id = tourSchedule.Id,
                TourId = tourSchedule.TourId,
                TourDate = tourSchedule.TourDate,
                IsCompleted = tourSchedule.IsCompleted,
                IsCancelled = tourSchedule.IsCancelled,
                TotalIncome = tourSchedule.TotalIncome,
                TotalExpense = tourSchedule.TotalExpense,
                NetProfit = tourSchedule.NetProfit,
                Notes = tourSchedule.Notes
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourId,TourDate,IsCompleted,IsCancelled,TotalIncome,TotalExpense,NetProfit,Notes")] TourScheduleEditViewModel updateDto)
        {
            if (id != updateDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<TourScheduleEditViewModel, TourScheduleViewModel>($"api/tourschedules/{updateDto.Id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourSchedule = await _apiService.GetAsync<TourScheduleViewModel>($"api/tourschedules/{id}");
            if (tourSchedule == null)
                return NotFound();

            return View(tourSchedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tourschedules/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
