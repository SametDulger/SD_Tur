using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class FinancialReportsController : Controller
    {
        private readonly IApiService _apiService;

        public FinancialReportsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var financialReports = await _apiService.GetAsync<List<FinancialReportDto>>("api/financialreports");
            return View(financialReports);
        }

        public async Task<IActionResult> Details(int id)
        {
            var financialReport = await _apiService.GetAsync<FinancialReportDto>($"api/financialreports/{id}");
            if (financialReport == null)
                return NotFound();
            return View(financialReport);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportType,ReportDate,StartDate,EndDate,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId")] CreateFinancialReportDto createFinancialReportDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateFinancialReportDto, FinancialReportDto>("api/financialreports", createFinancialReportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createFinancialReportDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var financialReport = await _apiService.GetAsync<FinancialReportDto>($"api/financialreports/{id}");
            if (financialReport == null)
                return NotFound();
            return View(financialReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportType,ReportDate,StartDate,EndDate,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId,IsActive")] UpdateFinancialReportDto updateFinancialReportDto)
        {
            if (id != updateFinancialReportDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateFinancialReportDto, FinancialReportDto>($"api/financialreports/{id}", updateFinancialReportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateFinancialReportDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var financialReport = await _apiService.GetAsync<FinancialReportDto>($"api/financialreports/{id}");
            if (financialReport == null)
                return NotFound();
            return View(financialReport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/financialreports/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 