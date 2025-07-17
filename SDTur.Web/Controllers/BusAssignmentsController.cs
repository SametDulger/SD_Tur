using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class BusAssignmentsController : Controller
    {
        private readonly IApiService _apiService;

        public BusAssignmentsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var busAssignments = await _apiService.GetAsync<List<BusAssignmentDto>>("api/busassignments");
            return View(busAssignments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentDto>($"api/busassignments/{id}");
            if (busAssignment == null)
                return NotFound();
            return View(busAssignment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusId,TourScheduleId,EmployeeId,AssignmentDate,Status,Notes")] CreateBusAssignmentDto createBusAssignmentDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateBusAssignmentDto, BusAssignmentDto>("api/busassignments", createBusAssignmentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createBusAssignmentDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentDto>($"api/busassignments/{id}");
            if (busAssignment == null)
                return NotFound();
            return View(busAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusId,TourScheduleId,EmployeeId,AssignmentDate,Status,Notes,IsActive")] UpdateBusAssignmentDto updateBusAssignmentDto)
        {
            if (id != updateBusAssignmentDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateBusAssignmentDto, BusAssignmentDto>($"api/busassignments/{id}", updateBusAssignmentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateBusAssignmentDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentDto>($"api/busassignments/{id}");
            if (busAssignment == null)
                return NotFound();
            return View(busAssignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/busassignments/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 