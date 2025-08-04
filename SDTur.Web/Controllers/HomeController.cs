using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Services;
using SDTur.Web.Models.Home;
using SDTur.Web.Models;

namespace SDTur.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IApiService apiService, ILogger<HomeController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                var dashboardViewModel = new DashboardViewModel
                {
                    RecentTours = new List<RecentTourViewModel>(),
                    UpcomingTours = new List<UpcomingTourViewModel>(),
                    RecentActivities = new List<RecentActivityViewModel>()
                };

                // Get tours data
                var tours = await _apiService.GetToursAsync();
                
                // Get tickets data
                var tickets = await _apiService.GetTicketsAsync();
                
                // Calculate statistics
                dashboardViewModel.TotalTours = tours.Count();
                dashboardViewModel.ActiveTours = tours.Count(t => t.IsActive);
                dashboardViewModel.TotalTickets = tickets.Count(t => !t.IsCancelled);
                dashboardViewModel.TotalRevenue = tickets.Where(t => !t.IsCancelled).Sum(t => t.TotalAmount);
                dashboardViewModel.TotalCustomers = tickets.Where(t => !t.IsCancelled).Count();

                // Get recent tours
                dashboardViewModel.RecentTours = tours
                    .OrderByDescending(t => t.Id)
                    .Take(5)
                    .Select(t => new RecentTourViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        StartDate = t.TourDate,
                        EndDate = t.TourDate.AddHours(t.Duration),
                        Status = t.IsActive ? "Active" : "Inactive"
                    })
                    .ToList();

                // Get upcoming tours
                dashboardViewModel.UpcomingTours = tours
                    .Where(t => t.TourDate > DateTime.Now)
                    .OrderBy(t => t.TourDate)
                    .Take(5)
                    .Select(t => new UpcomingTourViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        StartDate = t.TourDate,
                        EndDate = t.TourDate.AddHours(t.Duration),
                        Destination = t.Destination
                    })
                    .ToList();

                // Get recent activities (simulated)
                dashboardViewModel.RecentActivities = new List<RecentActivityViewModel>
                {
                    new RecentActivityViewModel
                    {
                        Id = 1,
                        Description = "Yeni tur oluşturuldu: İstanbul Turu",
                        Timestamp = DateTime.Now.AddHours(-2),
                        Type = "TourCreated"
                    },
                    new RecentActivityViewModel
                    {
                        Id = 2,
                        Description = "Bilet satışı yapıldı: #TK001",
                        Timestamp = DateTime.Now.AddHours(-4),
                        Type = "TicketSold"
                    },
                    new RecentActivityViewModel
                    {
                        Id = 3,
                        Description = "Müşteri kaydı oluşturuldu: Ahmet Yılmaz",
                        Timestamp = DateTime.Now.AddHours(-6),
                        Type = "CustomerCreated"
                    }
                };

                return View(dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dashboard data");
                TempData["Error"] = "Dashboard verileri yüklenirken bir hata oluştu.";
                return View(new DashboardViewModel());
            }
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Gizlilik";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
} 
