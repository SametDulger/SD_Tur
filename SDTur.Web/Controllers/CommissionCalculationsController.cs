using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
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
            var commissionCalculations = await _apiService.GetAsync<List<CommissionCalculationDto>>("api/commissioncalculations");
            return View(commissionCalculations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationDto>($"api/commissioncalculations/{id}");
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
        public async Task<IActionResult> Create([Bind("EmployeeId,TourScheduleId,TicketId,CalculationDate,CommissionAmount,Currency,CommissionType,CommissionRate,Status,Notes")] CreateCommissionCalculationDto createCommissionCalculationDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateCommissionCalculationDto, CommissionCalculationDto>("api/commissioncalculations", createCommissionCalculationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createCommissionCalculationDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationDto>($"api/commissioncalculations/{id}");
            if (commissionCalculation == null)
                return NotFound();
            return View(commissionCalculation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,TourScheduleId,TicketId,CalculationDate,CommissionAmount,Currency,CommissionType,CommissionRate,Status,Notes,IsActive")] UpdateCommissionCalculationDto updateCommissionCalculationDto)
        {
            if (id != updateCommissionCalculationDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateCommissionCalculationDto, CommissionCalculationDto>($"api/commissioncalculations/{id}", updateCommissionCalculationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateCommissionCalculationDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var commissionCalculation = await _apiService.GetAsync<CommissionCalculationDto>($"api/commissioncalculations/{id}");
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