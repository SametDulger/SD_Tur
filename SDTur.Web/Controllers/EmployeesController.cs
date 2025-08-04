using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.People;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IApiService _apiService;

        public EmployeesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("api/employees");
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
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,Position,Salary,CurrencyId,HireDate,IsActive")] EmployeeCreateViewModel createEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<EmployeeCreateViewModel, EmployeeViewModel>("api/employees", createEmployeeViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            return View(createEmployeeViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _apiService.GetAsync<EmployeeViewModel>($"api/employees/{id}");
            if (employee == null)
                return NotFound();
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,Position,Salary,CurrencyId,HireDate,IsActive")] EmployeeEditViewModel employeeEditViewModel)
        {
            if (id != employeeEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<EmployeeEditViewModel, EmployeeViewModel>($"api/employees/{id}", employeeEditViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            return View(employeeEditViewModel);
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
