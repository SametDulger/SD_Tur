using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class ServiceSchedulesController : Controller
    {
        private readonly IApiService _apiService;

        public ServiceSchedulesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var serviceSchedules = await _apiService.GetAsync<List<ServiceScheduleDto>>("api/serviceschedules");
            return View(serviceSchedules);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleDto>($"api/serviceschedules/{id}");
            if (serviceSchedule == null)
                return NotFound();

            return View(serviceSchedule);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceDate,ServiceTime,TourId,RegionId,IsActive")] CreateServiceScheduleDto createServiceScheduleDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateServiceScheduleDto, ServiceScheduleDto>("api/serviceschedules", createServiceScheduleDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createServiceScheduleDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleDto>($"api/serviceschedules/{id}");
            if (serviceSchedule == null)
                return NotFound();

            var updateDto = new UpdateServiceScheduleDto
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
        public async Task<IActionResult> Edit(int id, UpdateServiceScheduleDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateServiceScheduleDto, ServiceScheduleDto>($"api/serviceschedules/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serviceSchedule = await _apiService.GetAsync<ServiceScheduleDto>($"api/serviceschedules/{id}");
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