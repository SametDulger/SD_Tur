using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class ServiceSchedulesController : Controller
    {
        private readonly IApiService _apiService;

        public ServiceSchedulesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var serviceSchedules = await _apiService.GetAsync<List<ServiceScheduleViewModel>>("api/serviceschedules");
            return View(serviceSchedules);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleViewModel>($"api/serviceschedules/{id}");
            if (serviceSchedule == null)
                return NotFound();

            return View(serviceSchedule);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceDate,ServiceTime,TourId,RegionId,IsActive")] ServiceScheduleCreateViewModel createServiceScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<ServiceScheduleCreateViewModel, ServiceScheduleViewModel>("api/serviceschedules", createServiceScheduleViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(createServiceScheduleViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleViewModel>($"api/serviceschedules/{id}");
            if (serviceSchedule == null)
                return NotFound();

            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;

            var updateDto = new ServiceScheduleEditViewModel
            {
                Id = serviceSchedule.Id,
                TourId = serviceSchedule.TourId,
                RegionId = serviceSchedule.RegionId,
                ServiceTime = serviceSchedule.ServiceTime,
                IsActive = serviceSchedule.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceScheduleEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<ServiceScheduleEditViewModel, ServiceScheduleViewModel>($"api/serviceschedules/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleViewModel>($"api/serviceschedules/{id}");
            if (serviceSchedule == null)
                return NotFound();

            return View(serviceSchedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/serviceschedules/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
