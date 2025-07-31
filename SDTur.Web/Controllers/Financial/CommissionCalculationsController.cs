using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Financial
{
    public class CommissionCalculationsController : Controller
    {
        private readonly IApiService _apiService;

        public CommissionCalculationsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var commissionCalculations = await _apiService.GetAsync<List<CommissionCalculationViewModel>>("api/commissioncalculations");
            return View(commissionCalculations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationViewModel>($"api/commissioncalculations/{id}");
            if (commissionCalculation == null)
                return NotFound();
            return View(commissionCalculation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,TourScheduleId,TicketId,CalculationDate,CommissionAmount,Currency,CommissionType,CommissionRate,Status,Notes")] CreateCommissionCalculationViewModel createCommissionCalculationViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateCommissionCalculationViewModel, CommissionCalculationViewModel>("api/commissioncalculations", createCommissionCalculationViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createCommissionCalculationViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationViewModel>($"api/commissioncalculations/{id}");
            if (commissionCalculation == null)
                return NotFound();
            return View(commissionCalculation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,TourScheduleId,TicketId,CalculationDate,CommissionAmount,Currency,CommissionType,CommissionRate,Status,Notes,IsActive")] UpdateCommissionCalculationViewModel updateCommissionCalculationViewModel)
        {
            if (id != updateCommissionCalculationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateCommissionCalculationViewModel, CommissionCalculationViewModel>($"api/commissioncalculations/{id}", updateCommissionCalculationViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(updateCommissionCalculationViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationViewModel>($"api/commissioncalculations/{id}");
            if (commissionCalculation == null)
                return NotFound();
            return View(commissionCalculation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/commissioncalculations/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 