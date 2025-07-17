using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class TourReportsController : Controller
    {
        private readonly IApiService _apiService;

        public TourReportsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tourReports = await _apiService.GetAsync<List<TourReportDto>>("api/tourreports");
            return View(tourReports);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportDto>($"api/tourreports/{id}");
            if (tourReport == null)
                return NotFound();
            return View(tourReport);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,ReportType,ReportDate,StartDate,EndDate,TotalCustomers,FullPriceCustomers,HalfPriceCustomers,GuestCustomers,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId")] CreateTourReportDto createTourReportDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateTourReportDto, TourReportDto>("api/tourreports", createTourReportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createTourReportDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportDto>($"api/tourreports/{id}");
            if (tourReport == null)
                return NotFound();
            return View(tourReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,ReportType,ReportDate,StartDate,EndDate,TotalCustomers,FullPriceCustomers,HalfPriceCustomers,GuestCustomers,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId,IsActive")] UpdateTourReportDto updateTourReportDto)
        {
            if (id != updateTourReportDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateTourReportDto, TourReportDto>($"api/tourreports/{id}", updateTourReportDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateTourReportDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportDto>($"api/tourreports/{id}");
            if (tourReport == null)
                return NotFound();
            return View(tourReport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tourreports/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 