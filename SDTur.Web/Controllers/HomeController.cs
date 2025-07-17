using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tours = await _apiService.GetAsync<IEnumerable<TourDto>>("api/tours");
                var tourSchedules = await _apiService.GetAsync<IEnumerable<TourScheduleDto>>("api/tourschedules");
                var tickets = await _apiService.GetAsync<IEnumerable<TicketDto>>("api/tickets");
                var branches = await _apiService.GetAsync<IEnumerable<BranchDto>>("api/branches");
                var employees = await _apiService.GetAsync<IEnumerable<EmployeeDto>>("api/employees");

                ViewBag.TourCount = tours?.Count() ?? 0;
                ViewBag.ScheduleCount = tourSchedules?.Count() ?? 0;
                ViewBag.TicketCount = tickets?.Count() ?? 0;
                ViewBag.BranchCount = branches?.Count() ?? 0;
                ViewBag.EmployeeCount = employees?.Count() ?? 0;
                
                // Ek istatistikler için veri çekme
                var buses = await _apiService.GetAsync<IEnumerable<BusDto>>("api/buses");
                var hotels = await _apiService.GetAsync<IEnumerable<HotelDto>>("api/hotels");
                var reports = await _apiService.GetAsync<IEnumerable<ReportDto>>("api/reports");
                
                ViewBag.BusCount = buses?.Count() ?? 0;
                ViewBag.HotelCount = hotels?.Count() ?? 0;
                ViewBag.ReportCount = reports?.Count() ?? 0;

                return View();
            }
            catch
            {
                ViewBag.TourCount = 0;
                ViewBag.ScheduleCount = 0;
                ViewBag.TicketCount = 0;
                ViewBag.BranchCount = 0;
                ViewBag.EmployeeCount = 0;
                ViewBag.BusCount = 0;
                ViewBag.HotelCount = 0;
                ViewBag.ReportCount = 0;
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
