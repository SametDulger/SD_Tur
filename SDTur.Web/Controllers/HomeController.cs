using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models;

namespace SDTur.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Ana Sayfa";
            return View();
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
