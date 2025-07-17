using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
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
            var tours = await _apiService.GetAsync<List<TourDto>>("api/tours");
            return View(tours);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tour = await _apiService.GetAsync<TourDto>($"api/tours/{id}");
            if (tour == null)
                return NotFound();

            return View(tour);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTourDto createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PostAsync<CreateTourDto, TourDto>("api/tours", createDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _apiService.GetAsync<TourDto>($"api/tours/{id}");
            if (tour == null)
                return NotFound();

            var updateDto = new UpdateTourDto
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Price = tour.Price,
                Currency = tour.Currency,
                Duration = tour.Duration,
                IsActive = tour.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTourDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateTourDto, TourDto>($"api/tours/{updateDto.Id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _apiService.GetAsync<TourDto>($"api/tours/{id}");
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