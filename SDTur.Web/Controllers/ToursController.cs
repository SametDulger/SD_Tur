using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class ToursController : Controller
    {
        private readonly IApiService _apiService;

        public ToursController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            var viewModels = (tours ?? new List<TourViewModel>()).Select(t => new TourViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                TourDate = t.TourDate,
                Capacity = t.Capacity,
                AvailableSeats = t.AvailableSeats,
                IsActive = t.IsActive
            }).ToList();
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var t = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (t == null)
                return NotFound();
            var vm = new TourViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                TourDate = t.TourDate,
                Capacity = t.Capacity,
                AvailableSeats = t.AvailableSeats,
                IsActive = t.IsActive
            };
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            ViewBag.TourTypes = new List<TourTypeViewModel> 
            { 
                new TourTypeViewModel { Id = "Domestic", Name = "Yurt İçi" },
                new TourTypeViewModel { Id = "International", Name = "Yurt Dışı" },
                new TourTypeViewModel { Id = "Cultural", Name = "Kültür Turu" },
                new TourTypeViewModel { Id = "Adventure", Name = "Macera Turu" },
                new TourTypeViewModel { Id = "Relaxation", Name = "Dinlence Turu" }
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set required properties for API
                    vm.Duration = (int)(vm.EndDate - vm.StartDate).TotalDays;
                    vm.Destination = vm.DestinationLocation ?? vm.Destination;
                    vm.BasePrice = vm.Price;
                    
                    // Debug için log ekleyelim
                    Console.WriteLine($"Sending tour data: Name={vm.Name}, Price={vm.Price}, Duration={vm.Duration}, Destination={vm.Destination}");
                    
                    var result = await _apiService.PostAsync<TourCreateViewModel, TourViewModel>("api/tours", vm);
                    if (result != null)
                    {
                        TempData["Success"] = "Tur başarıyla oluşturuldu!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "API'den yanıt alınamadı");
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError("", $"API Hatası: {ex.Message}");
                    Console.WriteLine($"HTTP Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Beklenmeyen hata: {ex.Message}");
                    Console.WriteLine($"General Error: {ex.Message}");
                }
            }
            else
            {
                // Model validation hatalarını göster
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
            }
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            ViewBag.TourTypes = new List<TourTypeViewModel> 
            { 
                new TourTypeViewModel { Id = "Domestic", Name = "Yurt İçi" },
                new TourTypeViewModel { Id = "International", Name = "Yurt Dışı" },
                new TourTypeViewModel { Id = "Cultural", Name = "Kültür Turu" },
                new TourTypeViewModel { Id = "Adventure", Name = "Macera Turu" },
                new TourTypeViewModel { Id = "Relaxation", Name = "Dinlence Turu" }
            };
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (tour == null)
                return NotFound();
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            ViewBag.TourTypes = new List<TourTypeViewModel> 
            { 
                new TourTypeViewModel { Id = "Domestic", Name = "Yurt İçi" },
                new TourTypeViewModel { Id = "International", Name = "Yurt Dışı" },
                new TourTypeViewModel { Id = "Cultural", Name = "Kültür Turu" },
                new TourTypeViewModel { Id = "Adventure", Name = "Macera Turu" },
                new TourTypeViewModel { Id = "Relaxation", Name = "Dinlence Turu" }
            };
            
            var editViewModel = new TourEditViewModel
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Price = tour.Price,
                TourDate = tour.TourDate,
                Capacity = tour.Capacity,
                IsActive = tour.IsActive
            };
            
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TourEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                                 // Set required properties for API
                 vm.Duration = (int)(vm.EndDate - vm.StartDate).TotalDays;
                 vm.Destination = vm.DestinationLocation ?? vm.Destination;
                 vm.BasePrice = vm.Price;
                
                var result = await _apiService.PutAsync<TourEditViewModel, TourViewModel>($"api/tours/{vm.Id}", vm);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            
            var currencies = await _apiService.GetAsync<List<CurrencyViewModel>>("api/currencies");
            ViewBag.Currencies = currencies;
            ViewBag.TourTypes = new List<TourTypeViewModel> 
            { 
                new TourTypeViewModel { Id = "Domestic", Name = "Yurt İçi" },
                new TourTypeViewModel { Id = "International", Name = "Yurt Dışı" },
                new TourTypeViewModel { Id = "Cultural", Name = "Kültür Turu" },
                new TourTypeViewModel { Id = "Adventure", Name = "Macera Turu" },
                new TourTypeViewModel { Id = "Relaxation", Name = "Dinlence Turu" }
            };
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (tour == null)
                return NotFound();
            return View(tour);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tours/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
