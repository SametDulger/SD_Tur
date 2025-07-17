using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IApiService _apiService;

        public HotelsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _apiService.GetAsync<IEnumerable<HotelDto>>("api/hotels");
            return View(hotels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _apiService.GetAsync<HotelDto>($"api/hotels/{id}");
            if (hotel == null)
                return NotFound();

            return View(hotel);
        }

        public async Task<IActionResult> Create()
        {
            var regions = await _apiService.GetAsync<IEnumerable<RegionDto>>("api/regions");
            ViewBag.Regions = regions;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Phone,RegionId,Order,IsActive")] CreateHotelDto createHotelDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateHotelDto, HotelDto>("api/hotels", createHotelDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createHotelDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _apiService.GetAsync<HotelDto>($"api/hotels/{id}");
            if (hotel == null)
                return NotFound();

            var regions = await _apiService.GetAsync<IEnumerable<RegionDto>>("api/regions");
            ViewBag.Regions = regions;

            var updateDto = new UpdateHotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                Phone = hotel.Phone,
                RegionId = hotel.RegionId,
                Order = hotel.Order,
                IsActive = hotel.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateHotelDto updateHotelDto)
        {
            if (id != updateHotelDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateHotelDto, HotelDto>($"api/hotels/{id}", updateHotelDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            var regions = await _apiService.GetAsync<IEnumerable<RegionDto>>("api/regions");
            ViewBag.Regions = regions;
            return View(updateHotelDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _apiService.GetAsync<HotelDto>($"api/hotels/{id}");
            if (hotel == null)
                return NotFound();

            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/hotels/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 