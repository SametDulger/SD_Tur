using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Reports;
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
            try
            {
                var financialReports = await _apiService.GetFinancialReportsAsync();
                return View(financialReports);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal raporlar yüklenirken hata oluştu: " + ex.Message;
                return View(new List<FinancialReportViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var financialReport = await _apiService.GetFinancialReportByIdAsync(id);
                if (financialReport == null)
                {
                    TempData["Error"] = "Finansal rapor bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(financialReport);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;
                
                return View(new FinancialReportCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinancialReportCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateFinancialReportAsync(createViewModel);
                    TempData["Success"] = "Finansal rapor başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor oluşturulurken hata oluştu: " + ex.Message;
                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var financialReport = await _apiService.GetFinancialReportByIdAsync(id);
                if (financialReport == null)
                {
                    TempData["Error"] = "Finansal rapor bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;

                var updateViewModel = new FinancialReportEditViewModel
                {
                    Id = financialReport.Id,
                    ReportType = financialReport.ReportType,
                    ReportDate = financialReport.ReportDate,
                    StartDate = financialReport.StartDate,
                    EndDate = financialReport.EndDate,
                    TotalIncome = financialReport.TotalIncome,
                    TotalExpense = financialReport.TotalExpense,
                    NetProfit = financialReport.NetProfit,
                    Currency = financialReport.Currency,
                    ReportData = financialReport.ReportData,
                    Status = financialReport.Status,
                    EmployeeId = financialReport.EmployeeId,
                    IsActive = financialReport.IsActive
                };

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FinancialReportEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateFinancialReportAsync(updateViewModel);
                    TempData["Success"] = "Finansal rapor başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor güncellenirken hata oluştu: " + ex.Message;
                var employees = await _apiService.GetEmployeesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var financialReport = await _apiService.GetFinancialReportByIdAsync(id);
                if (financialReport == null)
                {
                    TempData["Error"] = "Finansal rapor bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(financialReport);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteFinancialReportAsync(id);
                TempData["Success"] = "Finansal rapor başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Finansal rapor silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
