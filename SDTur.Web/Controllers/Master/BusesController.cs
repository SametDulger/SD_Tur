using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Master.Transport;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Master
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
            var buses = await _apiService.GetAsync<IEnumerable<BusViewModel>>("api/buses");
            return View(buses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bus = await _apiService.GetAsync<BusViewModel>($"api/buses/{id}");
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
        public async Task<IActionResult> Create([Bind("PlateNumber,Capacity,Model,DriverName,DriverPhone,IsOwned,IsActive")] BusCreateViewModel BusCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<BusCreateViewModel, BusViewModel>("api/buses", BusCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(BusCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _apiService.GetAsync<BusViewModel>($"api/buses/{id}");
            if (bus == null)
                return NotFound();

            var updateDto = new BusEditViewModel
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
        public async Task<IActionResult> Edit(int id, BusEditViewModel BusEditViewModel)
        {
            if (id != BusEditViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<BusEditViewModel, BusViewModel>($"api/buses/{id}", BusEditViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(BusEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bus = await _apiService.GetAsync<BusViewModel>($"api/buses/{id}");
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