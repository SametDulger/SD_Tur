using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.Transport;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class BusesController : Controller
    {
        private readonly IApiService _apiService;

        public BusesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var buses = await _apiService.GetBusesAsync();
                return View(buses);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüsler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<BusViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var bus = await _apiService.GetBusByIdAsync(id);
                if (bus == null)
                {
                    TempData["Error"] = "Otobüs bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(bus);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Create()
        {
            return View(new BusCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateBusAsync(createViewModel);
                    TempData["Success"] = "Otobüs başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs oluşturulurken hata oluştu: " + ex.Message;
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var bus = await _apiService.GetBusByIdAsync(id);
                if (bus == null)
                {
                    TempData["Error"] = "Otobüs bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var updateViewModel = new BusEditViewModel
                {
                    Id = bus.Id,
                    PlateNumber = bus.PlateNumber,
                    Brand = bus.Brand,
                    Model = bus.Model,
                    Year = bus.Year,
                    Capacity = bus.Capacity,
                    DriverName = bus.DriverName,
                    DriverPhone = bus.DriverPhone,
                    DriverLicense = bus.DriverLicense,
                    LastMaintenanceDate = bus.LastMaintenanceDate,
                    NextMaintenanceDate = bus.NextMaintenanceDate,
                    IsActive = bus.IsActive,
                    Description = bus.Description
                };

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateBusAsync(updateViewModel);
                    TempData["Success"] = "Otobüs başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs güncellenirken hata oluştu: " + ex.Message;
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bus = await _apiService.GetBusByIdAsync(id);
                if (bus == null)
                {
                    TempData["Error"] = "Otobüs bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(bus);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteBusAsync(id);
                TempData["Success"] = "Otobüs başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Otobüs silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
