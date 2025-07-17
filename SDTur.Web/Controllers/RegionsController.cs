using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
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
            var regions = await _apiService.GetAsync<IEnumerable<RegionDto>>("api/regions");
            return View(regions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var region = await _apiService.GetAsync<RegionDto>($"api/regions/{id}");
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
        public async Task<IActionResult> Create([Bind("Name,Description,DistanceFromKemer,Order,IsActive")] CreateRegionDto createRegionDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateRegionDto, RegionDto>("api/regions", createRegionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createRegionDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var region = await _apiService.GetAsync<RegionDto>($"api/regions/{id}");
            if (region == null)
                return NotFound();

            var updateDto = new UpdateRegionDto
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
        public async Task<IActionResult> Edit(int id, UpdateRegionDto updateRegionDto)
        {
            if (id != updateRegionDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateRegionDto, RegionDto>($"api/regions/{id}", updateRegionDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateRegionDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var region = await _apiService.GetAsync<RegionDto>($"api/regions/{id}");
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