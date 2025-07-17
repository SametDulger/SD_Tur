using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class BusesController : Controller
    {
        private readonly IApiService _apiService;

        public BusesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var buses = await _apiService.GetAsync<IEnumerable<BusDto>>("api/buses");
            return View(buses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bus = await _apiService.GetAsync<BusDto>($"api/buses/{id}");
            if (bus == null)
                return NotFound();

            return View(bus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlateNumber,Capacity,Model,DriverName,DriverPhone,IsOwned,IsActive")] CreateBusDto createBusDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateBusDto, BusDto>("api/buses", createBusDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createBusDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _apiService.GetAsync<BusDto>($"api/buses/{id}");
            if (bus == null)
                return NotFound();

            var updateDto = new UpdateBusDto
            {
                Id = bus.Id,
                PlateNumber = bus.PlateNumber,
                Model = bus.Model,
                Capacity = bus.Capacity,
                DriverName = bus.DriverName,
                DriverPhone = bus.DriverPhone,
                IsOwned = bus.IsOwned,
                IsActive = bus.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBusDto updateBusDto)
        {
            if (id != updateBusDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateBusDto, BusDto>($"api/buses/{id}", updateBusDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateBusDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bus = await _apiService.GetAsync<BusDto>($"api/buses/{id}");
            if (bus == null)
                return NotFound();

            return View(bus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/buses/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 