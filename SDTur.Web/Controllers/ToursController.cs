using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Core;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new TourCreateViewModel
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Price = vm.Price,
                    TourDate = vm.TourDate,
                    Capacity = vm.Capacity,
                    IsActive = vm.IsActive
                };
                var result = await _apiService.PostAsync<TourCreateViewModel, TourViewModel>("api/tours", dto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var t = await _apiService.GetAsync<TourViewModel>($"api/tours/{id}");
            if (t == null)
                return NotFound();
            var vm = new TourEditViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                TourDate = t.TourDate,
                Capacity = t.Capacity,
                IsActive = t.IsActive
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TourEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new TourEditViewModel
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                    Price = vm.Price,
                    TourDate = vm.TourDate,
                    Capacity = vm.Capacity,
                    IsActive = vm.IsActive
                };
                var result = await _apiService.PutAsync<TourEditViewModel, TourViewModel>($"api/tours/{vm.Id}", dto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/tours/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
