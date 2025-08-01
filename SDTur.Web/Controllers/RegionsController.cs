using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Master.Locations;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IApiService _apiService;

        public RegionsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var regions = await _apiService.GetAsync<IEnumerable<RegionViewModel>>("api/regions");
            return View(regions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var region = await _apiService.GetAsync<RegionViewModel>($"api/regions/{id}");
            if (region == null)
                return NotFound();

            return View(region);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,DistanceFromKemer,Order,IsActive")] RegionCreateViewModel RegionCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<RegionCreateViewModel, RegionViewModel>("api/regions", RegionCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(RegionCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var region = await _apiService.GetAsync<RegionViewModel>($"api/regions/{id}");
            if (region == null)
                return NotFound();

            var updateDto = new RegionEditViewModel
            {
                Id = region.Id,
                Name = region.Name,
                Description = region.Description,
                DistanceFromKemer = region.DistanceFromKemer,
                Order = region.Order,
                IsActive = region.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegionEditViewModel RegionEditViewModel)
        {
            if (id != RegionEditViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<RegionEditViewModel, RegionViewModel>($"api/regions/{id}", RegionEditViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(RegionEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var region = await _apiService.GetAsync<RegionViewModel>($"api/regions/{id}");
            if (region == null)
                return NotFound();

            return View(region);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/regions/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
