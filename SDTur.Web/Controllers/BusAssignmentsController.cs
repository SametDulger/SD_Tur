using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Master.Transport;
using SDTur.Web.Models.Master.People;
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

        public async Task<IActionResult> Create()
        {
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleViewModel>>("api/tourschedules");
            var buses = await _apiService.GetAsync<List<BusViewModel>>("api/buses");
            var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("api/employees");
            
            ViewBag.TourSchedules = tourSchedules;
            ViewBag.Buses = buses;
            ViewBag.Employees = employees;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,BusId,EmployeeId,AssignmentDate,Notes,IsActive")] BusAssignmentCreateViewModel createBusAssignmentViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<BusAssignmentCreateViewModel, BusAssignmentViewModel>("api/busassignments", createBusAssignmentViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleViewModel>>("api/tourschedules");
            var buses = await _apiService.GetAsync<List<BusViewModel>>("api/buses");
            var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("api/employees");
            
            ViewBag.TourSchedules = tourSchedules;
            ViewBag.Buses = buses;
            ViewBag.Employees = employees;
            return View(createBusAssignmentViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var busAssignment = await _apiService.GetAsync<BusAssignmentViewModel>($"api/busassignments/{id}");
            if (busAssignment == null)
                return NotFound();
            
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleViewModel>>("api/tourschedules");
            var buses = await _apiService.GetAsync<List<BusViewModel>>("api/buses");
            var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("api/employees");
            
            ViewBag.TourSchedules = tourSchedules;
            ViewBag.Buses = buses;
            ViewBag.Employees = employees;
            return View(busAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,BusId,EmployeeId,AssignmentDate,Notes,IsActive")] BusAssignmentEditViewModel busAssignmentEditViewModel)
        {
            if (id != busAssignmentEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<BusAssignmentEditViewModel, BusAssignmentViewModel>($"api/busassignments/{id}", busAssignmentEditViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tourSchedules = await _apiService.GetAsync<List<TourScheduleViewModel>>("api/tourschedules");
            var buses = await _apiService.GetAsync<List<BusViewModel>>("api/buses");
            var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("api/employees");
            
            ViewBag.TourSchedules = tourSchedules;
            ViewBag.Buses = buses;
            ViewBag.Employees = employees;
            return View(busAssignmentEditViewModel);
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
