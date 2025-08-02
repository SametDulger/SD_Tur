using Microsoft.AspNetCore.Mvc;
using SDTur.Application.Services.Financial.Interfaces;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly ITicketService _ticketService;
        private readonly IAccountService _accountService;
        private readonly ITourScheduleService _tourScheduleService;

        public DashboardController(
            ITourService tourService,
            ITicketService ticketService,
            IAccountService accountService,
            ITourScheduleService tourScheduleService)
        {
            _tourService = tourService;
            _ticketService = ticketService;
            _accountService = accountService;
            _tourScheduleService = tourScheduleService;
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<object>> GetStatistics()
        {
            try
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;
                var lastMonth = currentMonth == 1 ? 12 : currentMonth - 1;
                var lastYear = currentMonth == 1 ? currentYear - 1 : currentYear;

                // Get all data and filter in memory
                var allTours = await _tourService.GetAllToursAsync();
                var allTickets = await _ticketService.GetAllTicketsAsync();

                // Filter current month data
                var currentMonthTours = allTours.Where(t => t.CreatedDate.Month == currentMonth && t.CreatedDate.Year == currentYear);
                var currentMonthTickets = allTickets.Where(t => t.TicketDate.Month == currentMonth && t.TicketDate.Year == currentYear);

                // Filter last month data
                var lastMonthTours = allTours.Where(t => t.CreatedDate.Month == lastMonth && t.CreatedDate.Year == lastYear);
                var lastMonthTickets = allTickets.Where(t => t.TicketDate.Month == lastMonth && t.TicketDate.Year == lastYear);

                // Calculate statistics
                var activeTours = currentMonthTours.Count();
                var soldTickets = currentMonthTickets.Count();
                var monthlyIncome = currentMonthTickets.Sum(t => t.TotalAmount);
                var activeCustomers = currentMonthTickets.Select(t => t.CustomerName).Distinct().Count();

                // Calculate growth percentages
                var tourGrowth = lastMonthTours.Count() > 0 
                    ? Math.Round(((double)(activeTours - lastMonthTours.Count()) / lastMonthTours.Count()) * 100, 1)
                    : 0;

                var ticketGrowth = lastMonthTickets.Count() > 0
                    ? Math.Round(((double)(soldTickets - lastMonthTickets.Count()) / lastMonthTickets.Count()) * 100, 1)
                    : 0;

                var lastMonthIncome = lastMonthTickets.Sum(t => t.TotalAmount);
                var incomeGrowth = lastMonthIncome > 0
                    ? Math.Round(((double)((decimal)(monthlyIncome - lastMonthIncome) / lastMonthIncome)) * 100, 1)
                    : 0;

                var lastMonthCustomers = lastMonthTickets.Select(t => t.CustomerName).Distinct().Count();
                var customerGrowth = lastMonthCustomers > 0
                    ? Math.Round(((double)(activeCustomers - lastMonthCustomers) / lastMonthCustomers) * 100, 1)
                    : 0;

                return Ok(new
                {
                    activeTours,
                    soldTickets,
                    monthlyIncome,
                    activeCustomers,
                    tourGrowth,
                    ticketGrowth,
                    incomeGrowth,
                    customerGrowth
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "İstatistikler yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("monthly-income")]
        public async Task<ActionResult<object>> GetMonthlyIncome()
        {
            try
            {
                var currentYear = DateTime.Now.Year;
                var monthlyData = new List<decimal>();

                var allTickets = await _ticketService.GetAllTicketsAsync();

                for (int month = 1; month <= 6; month++)
                {
                    var monthTickets = allTickets.Where(t => t.TicketDate.Month == month && t.TicketDate.Year == currentYear);
                    monthlyData.Add(monthTickets.Sum(t => t.TotalAmount));
                }

                var labels = new[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran" };

                return Ok(new
                {
                    labels,
                    values = monthlyData
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Aylık gelir verisi yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("tour-distribution")]
        public async Task<ActionResult<object>> GetTourDistribution()
        {
            try
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                var allTours = await _tourService.GetAllToursAsync();
                var tours = allTours.Where(t => t.CreatedDate.Month == currentMonth && t.CreatedDate.Year == currentYear);

                // Simple distribution based on tour types (you can modify this based on your actual tour types)
                var domesticTours = tours.Count(t => t.Destination.Contains("Türkiye") || t.Destination.Contains("İstanbul") || t.Destination.Contains("Antalya"));
                var internationalTours = tours.Count(t => !t.Destination.Contains("Türkiye") && !t.Destination.Contains("İstanbul") && !t.Destination.Contains("Antalya"));
                var dayTours = tours.Count(t => t.Duration <= 1);

                var labels = new[] { "Yurt İçi", "Yurt Dışı", "Günübirlik" };
                var values = new[] { domesticTours, internationalTours, dayTours };

                return Ok(new
                {
                    labels,
                    values
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Tur dağılımı verisi yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("quick-actions")]
        public ActionResult<object> GetQuickActions()
        {
            try
            {
                var quickActions = new[]
                {
                    new { title = "Yeni Tur Ekle", description = "Yeni tur oluştur", url = "/Tour/Tours/Create", icon = "plus-circle", color = "primary" },
                    new { title = "Bilet Sat", description = "Yeni bilet satışı", url = "/Tour/Tickets/Create", icon = "ticket-perforated", color = "success" },
                    new { title = "Nakit İşlemi", description = "Nakit giriş/çıkış", url = "/Financial/Cash/Create", icon = "cash-coin", color = "warning" },
                    new { title = "Rapor Oluştur", description = "Finansal rapor", url = "/Financial/FinancialReports/Create", icon = "file-earmark-text", color = "info" }
                };

                return Ok(quickActions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Hızlı işlemler yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("recent-activities")]
        public ActionResult<object> GetRecentActivities()
        {
            try
            {
                var activities = new[]
                {
                    new { title = "Yeni Tur Eklendi", description = "Kapadokya Turu oluşturuldu", timeAgo = "2 saat önce", icon = "airplane", color = "primary" },
                    new { title = "Bilet Satıldı", description = "İstanbul Turu için 3 bilet", timeAgo = "4 saat önce", icon = "ticket-perforated", color = "success" },
                    new { title = "Ödeme Alındı", description = "₺1,500 nakit ödeme", timeAgo = "6 saat önce", icon = "cash-coin", color = "warning" },
                    new { title = "Rapor Oluşturuldu", description = "Aylık finansal rapor", timeAgo = "1 gün önce", icon = "file-earmark-text", color = "info" }
                };

                return Ok(activities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Son aktiviteler yüklenirken hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("upcoming-tours")]
        public async Task<ActionResult<object>> GetUpcomingTours()
        {
            try
            {
                var allSchedules = await _tourScheduleService.GetAllTourSchedulesAsync();
                var upcomingSchedules = allSchedules
                    .Where(s => s.TourDate >= DateTime.Now.Date && !s.IsCompleted && !s.IsCancelled)
                    .OrderBy(s => s.TourDate)
                    .Take(5);

                var tours = upcomingSchedules.Select(schedule => new
                {
                    id = schedule.Id,
                    name = schedule.TourName,
                    destination = "", // Not available in DTO
                    startDate = schedule.TourDate.ToString("dd.MM.yyyy"),
                    duration = 0, // Not available in DTO
                    totalSeats = schedule.MaxCapacity,
                    bookedSeats = schedule.CurrentCapacity,
                    capacityPercentage = schedule.MaxCapacity > 0 ? Math.Round((double)schedule.CurrentCapacity / schedule.MaxCapacity * 100, 1) : 0,
                    status = schedule.TourDate.Date == DateTime.Now.Date ? "Bugün" : 
                             schedule.TourDate.Date <= DateTime.Now.Date.AddDays(7) ? "Yakında" : "Aktif"
                });

                return Ok(tours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Yaklaşan turlar yüklenirken hata oluştu", details = ex.Message });
            }
        }
    }
} 