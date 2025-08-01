using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Master.People;
using SDTur.Web.Models.Master.Locations;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IApiService _apiService;

        public EmployeesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _apiService.GetAsync<IEnumerable<EmployeeViewModel>>("api/employees");
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeViewModel>($"api/employees/{id}");
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            var branches = await _apiService.GetAsync<IEnumerable<BranchViewModel>>("api/branches");
            ViewBag.Branches = branches;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,Position,Salary,CurrencyId,HireDate,CommissionRate,BranchId,IsActive")] EmployeeCreateViewModel createEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<EmployeeCreateViewModel, EmployeeViewModel>("api/employees", createEmployeeViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createEmployeeViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeViewModel>($"api/employees/{id}");
            if (employee == null)
                return NotFound();

            var branches = await _apiService.GetAsync<IEnumerable<BranchViewModel>>("api/branches");
            ViewBag.Branches = branches;

            var updateDto = new EmployeeEditViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Position = employee.Position,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                CurrencyId = employee.CurrencyId,
                CommissionRate = employee.CommissionRate,
                BranchId = employee.BranchId,
                IsActive = employee.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel EmployeeEditViewModel)
        {
            if (id != EmployeeEditViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<EmployeeEditViewModel, EmployeeViewModel>($"api/employees/{id}", EmployeeEditViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            var branches = await _apiService.GetAsync<IEnumerable<BranchViewModel>>("api/branches");
            ViewBag.Branches = branches;
            return View(EmployeeEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeViewModel>($"api/employees/{id}");
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/employees/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
