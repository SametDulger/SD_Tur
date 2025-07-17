using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class TourOperationsController : Controller
    {
        private readonly IApiService _apiService;

        public TourOperationsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourOperations = await _apiService.GetAsync<List<TourOperationDto>>("api/touroperations");
            return View(tourOperations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourOperation = await _apiService.GetAsync<TourOperationDto>($"api/touroperations/{id}");
            if (tourOperation == null)
                return NotFound();
            return View(tourOperation);
        }

        public async Task<IActionResult> Create()
        {
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleDto>>("api/tourschedules");
            ViewBag.TourSchedules = tourSchedules;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,BusId,EmployeeId,OperationDate,OperationType,Status,Notes")] CreateTourOperationDto createDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateTourOperationDto, TourOperationDto>("api/touroperations", createDto);
                return RedirectToAction(nameof(Index));
            }
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleDto>>("api/tourschedules");
            ViewBag.TourSchedules = tourSchedules;
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourOperation = await _apiService.GetAsync<TourOperationDto>($"api/touroperations/{id}");
            if (tourOperation == null)
                return NotFound();

            var updateDto = new UpdateTourOperationDto
            {
                Id = tourOperation.Id,
                TourScheduleId = tourOperation.TourScheduleId,
                BusId = tourOperation.BusId,
                EmployeeId = tourOperation.EmployeeId,
                OperationDate = tourOperation.OperationDate,
                OperationType = tourOperation.OperationType,
                Status = tourOperation.Status,
                Notes = tourOperation.Notes,
                IsActive = tourOperation.IsActive
            };

            var tourSchedules = await _apiService.GetAsync<List<TourScheduleDto>>("api/tourschedules");
            ViewBag.TourSchedules = tourSchedules;
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,BusId,EmployeeId,OperationDate,OperationType,Status,Notes,IsActive")] UpdateTourOperationDto updateDto)
        {
            if (id != updateDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateTourOperationDto, TourOperationDto>($"api/touroperations/{updateDto.Id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleDto>>("api/tourschedules");
            ViewBag.TourSchedules = tourSchedules;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourOperation = await _apiService.GetAsync<TourOperationDto>($"api/touroperations/{id}");
            if (tourOperation == null)
                return NotFound();
            return View(tourOperation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/touroperations/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 