using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models;
using SDTur.Web.Models.Home;

namespace SDTur.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Ana Sayfa";
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";
            
            // Set ViewBag properties to prevent runtime binding exceptions
            ViewBag.ActiveToursCount = 0;
            ViewBag.ToursGrowth = 0;
            ViewBag.SoldTicketsCount = 0;
            ViewBag.TicketsGrowth = 0;
            ViewBag.MonthlyIncome = 0m;
            ViewBag.IncomeGrowth = 0;
            ViewBag.ActiveCustomersCount = 0;
            ViewBag.CustomersGrowth = 0;
            ViewBag.RecentActivities = new List<RecentActivityViewModel>();
            ViewBag.UpcomingTours = new List<UpcomingTourViewModel>();
            
            return View("Dashboard");
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
