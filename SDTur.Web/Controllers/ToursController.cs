using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class ToursController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<ToursController> _logger;

        public ToursController(IApiService apiService, ILogger<ToursController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _apiService.GetToursAsync();
            return View(tours);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var tour = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        public async Task<IActionResult> Create()
        {
            var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
            ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,TourDate,Capacity,TourTypeId,Duration,Destination,Currency")] TourCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
                ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();
                
                return View(vm);
            }

            var tour = await _apiService.PostAsync<TourCreateViewModel, TourViewModel>("api/tours", vm);
            if (tour != null)
            {
                TempData["Success"] = "Tur başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error"] = "Tur oluşturulurken bir hata oluştu.";
                
                var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
                ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();
                
                return View(vm);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var tour = await _apiService.GetAsync<TourEditViewModel>($"api/tours/{id}");
            if (tour == null)
            {
                return NotFound();
            }

            // Load tour types for the dropdown
            var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
            ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();

            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,TourDate,Capacity,TourTypeId,Duration,Destination,Currency")] TourEditViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // Reload tour types for the view
                var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
                ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();
                
                return View(vm);
            }

            var tour = await _apiService.PutAsync<TourEditViewModel, TourViewModel>($"api/tours/{id}", vm);
            if (tour != null)
            {
                TempData["Success"] = "Tur başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error"] = "Tur güncellenirken bir hata oluştu.";
                
                // Reload tour types for the view
                var tourTypes = await _apiService.GetAsync<List<TourTypeViewModel>>("api/tourtypes/active");
                ViewBag.TourTypes = tourTypes ?? new List<TourTypeViewModel>();
                
                return View(vm);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var tour = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tours/{id}");
            TempData["Success"] = "Tur başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
} 
