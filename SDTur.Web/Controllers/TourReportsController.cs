using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Financial;
using SDTur.Web.Models.Tour.Core;
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
            var tourReports = await _apiService.GetAsync<List<TourReportViewModel>>("api/tourreports");
            return View(tourReports);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportViewModel>($"api/tourreports/{id}");
            if (tourReport == null)
                return NotFound();
            return View(tourReport);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourScheduleId,ReportType,ReportDate,StartDate,EndDate,TotalCustomers,FullPriceCustomers,HalfPriceCustomers,GuestCustomers,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId")] TourReportCreateViewModel createTourReportViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<TourReportCreateViewModel, TourReportViewModel>("api/tourreports", createTourReportViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(createTourReportViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportViewModel>($"api/tourreports/{id}");
            if (tourReport == null)
                return NotFound();
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(tourReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourScheduleId,ReportType,ReportDate,StartDate,EndDate,TotalCustomers,FullPriceCustomers,HalfPriceCustomers,GuestCustomers,TotalIncome,TotalExpense,NetProfit,Currency,ReportData,Status,EmployeeId,IsActive")] TourReportEditViewModel updateTourReportViewModel)
        {
            if (id != updateTourReportViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<TourReportEditViewModel, TourReportViewModel>($"api/tourreports/{id}", updateTourReportViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
            return View(updateTourReportViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tourReport = await _apiService.GetAsync<TourReportViewModel>($"api/tourreports/{id}");
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
