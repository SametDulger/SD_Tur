using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Tour
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
            var busAssignments = await _apiService.GetAsync<List<BusAssignmentViewModel>>("api/busassignments");
            return View(busAssignments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentViewModel>($"api/busassignments/{id}");
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
        public async Task<IActionResult> Create([Bind("BusId,TourScheduleId,EmployeeId,AssignmentDate,Status,Notes")] CreateBusAssignmentViewModel createBusAssignmentViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateBusAssignmentViewModel, BusAssignmentViewModel>("api/busassignments", createBusAssignmentViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createBusAssignmentViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentViewModel>($"api/busassignments/{id}");
            if (busAssignment == null)
                return NotFound();
            return View(busAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusId,TourScheduleId,EmployeeId,AssignmentDate,Status,Notes,IsActive")] UpdateBusAssignmentViewModel updateBusAssignmentViewModel)
        {
            if (id != updateBusAssignmentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateBusAssignmentViewModel, BusAssignmentViewModel>($"api/busassignments/{id}", updateBusAssignmentViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(updateBusAssignmentViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentViewModel>($"api/busassignments/{id}");
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