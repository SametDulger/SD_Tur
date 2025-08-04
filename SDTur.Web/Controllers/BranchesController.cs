using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.Branches;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        private readonly IApiService _apiService;

        public BranchesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var branches = await _apiService.GetBranchesAsync();
                return View(branches);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şubeler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<BranchViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var branch = await _apiService.GetBranchByIdAsync(id);
                if (branch == null)
                {
                    TempData["Error"] = "Şube bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(branch);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Create()
        {
            return View(new BranchCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BranchCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateBranchAsync(createViewModel);
                    TempData["Success"] = "Şube başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube oluşturulurken hata oluştu: " + ex.Message;
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var branch = await _apiService.GetBranchByIdAsync(id);
                if (branch == null)
                {
                    TempData["Error"] = "Şube bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var updateViewModel = new BranchEditViewModel
                {
                    Id = branch.Id,
                    BranchName = branch.BranchName,
                    BranchCode = branch.BranchCode,
                    Address = branch.Address,
                    Phone = branch.Phone,
                    Email = branch.Email,
                    ManagerName = branch.ManagerName,
                    IsActive = branch.IsActive,
                    Description = branch.Description
                };

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BranchEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateBranchAsync(updateViewModel);
                    TempData["Success"] = "Şube başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube güncellenirken hata oluştu: " + ex.Message;
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var branch = await _apiService.GetBranchByIdAsync(id);
                if (branch == null)
                {
                    TempData["Error"] = "Şube bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(branch);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteBranchAsync(id);
                TempData["Success"] = "Şube başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Şube silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
