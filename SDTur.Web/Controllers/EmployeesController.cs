using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
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
            var employees = await _apiService.GetAsync<IEnumerable<EmployeeDto>>("api/employees");
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeDto>($"api/employees/{id}");
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            var branches = await _apiService.GetAsync<IEnumerable<BranchDto>>("api/branches");
            ViewBag.Branches = branches;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,Position,Salary,CurrencyId,HireDate,CommissionRate,BranchId,IsActive")] CreateEmployeeDto createEmployeeDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateEmployeeDto, EmployeeDto>("api/employees", createEmployeeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createEmployeeDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeDto>($"api/employees/{id}");
            if (employee == null)
                return NotFound();

            var branches = await _apiService.GetAsync<IEnumerable<BranchDto>>("api/branches");
            ViewBag.Branches = branches;

            var updateDto = new UpdateEmployeeDto
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
        public async Task<IActionResult> Edit(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            if (id != updateEmployeeDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateEmployeeDto, EmployeeDto>($"api/employees/{id}", updateEmployeeDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            var branches = await _apiService.GetAsync<IEnumerable<BranchDto>>("api/branches");
            ViewBag.Branches = branches;
            return View(updateEmployeeDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeDto>($"api/employees/{id}");
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