using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.System.Reports;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.System
{
    public class ReportsController : Controller
    {
        private readonly IApiService _apiService;

        public ReportsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var reports = await _apiService.GetAsync<List<ReportViewModel>>("api/reports");
            return View(reports);
        }

        public async Task<IActionResult> Details(int id)
        {
            var report = await _apiService.GetAsync<ReportViewModel>($"api/reports/{id}");
            if (report == null)
                return NotFound();
            return View(report);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportName,ReportType,ReportDate,Parameters,GeneratedBy,FilePath,FileType,IsActive")] CreateReportViewModel createDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateReportViewModel, ReportViewModel>("api/reports", createDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var report = await _apiService.GetAsync<ReportViewModel>($"api/reports/{id}");
            if (report == null)
                return NotFound();

            var updateDto = new UpdateReportViewModel
            {
                Id = report.Id,
                ReportName = report.ReportName,
                ReportType = report.ReportType,
                ReportDate = report.ReportDate,
                Parameters = report.Parameters,
                GeneratedBy = report.GeneratedBy,
                FilePath = report.FilePath,
                FileType = report.FileType,
                IsActive = report.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportName,ReportType,ReportDate,Parameters,GeneratedBy,FilePath,FileType,IsActive")] UpdateReportViewModel updateDto)
        {
            if (id != updateDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateReportViewModel, ReportViewModel>($"api/reports/{updateDto.Id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var report = await _apiService.GetAsync<ReportViewModel>($"api/reports/{id}");
            if (report == null)
                return NotFound();
            return View(report);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/reports/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport(string reportType, string parameters)
        {
            var filePath = await _apiService.PostAsync<object, string>($"api/reports/generate?reportType={reportType}&parameters={parameters}", null);
            return Json(new { filePath });
        }
    }
} 