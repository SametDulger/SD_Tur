using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class CustomerDistributionsController : Controller
    {
        private readonly IApiService _apiService;

        public CustomerDistributionsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var customerDistributions = await _apiService.GetAsync<List<CustomerDistributionDto>>("api/customerdistributions");
            return View(customerDistributions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customerDistribution = await _apiService.GetAsync<CustomerDistributionDto>($"api/customerdistributions/{id}");
            if (customerDistribution == null)
                return NotFound();
            return View(customerDistribution);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,BusId,TicketId,EmployeeId,DistributionDate,Status,Notes")] CreateCustomerDistributionDto createCustomerDistributionDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateCustomerDistributionDto, CustomerDistributionDto>("api/customerdistributions", createCustomerDistributionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createCustomerDistributionDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customerDistribution = await _apiService.GetAsync<CustomerDistributionDto>($"api/customerdistributions/{id}");
            if (customerDistribution == null)
                return NotFound();
            return View(customerDistribution);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,BusId,TicketId,EmployeeId,DistributionDate,Status,Notes,IsActive")] UpdateCustomerDistributionDto updateCustomerDistributionDto)
        {
            if (id != updateCustomerDistributionDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateCustomerDistributionDto, CustomerDistributionDto>($"api/customerdistributions/{id}", updateCustomerDistributionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateCustomerDistributionDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customerDistribution = await _apiService.GetAsync<CustomerDistributionDto>($"api/customerdistributions/{id}");
            if (customerDistribution == null)
                return NotFound();
            return View(customerDistribution);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/customerdistributions/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 