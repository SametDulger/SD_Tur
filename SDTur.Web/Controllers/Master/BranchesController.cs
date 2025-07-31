using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Master.Locations;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Master
{
    public class BranchesController : Controller
    {
        private readonly IApiService _apiService;

        public BranchesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _apiService.GetAsync<IEnumerable<BranchViewModel>>("api/branches");
            return View(branches);
        }

        public async Task<IActionResult> Details(int id)
        {
            var branch = await _apiService.GetAsync<BranchViewModel>($"api/branches/{id}");
            if (branch == null)
                return NotFound();

            return View(branch);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Phone,Email,IsActive")] BranchCreateViewModel BranchCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<BranchCreateViewModel, BranchViewModel>("api/branches", BranchCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(BranchCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var branch = await _apiService.GetAsync<BranchViewModel>($"api/branches/{id}");
            if (branch == null)
                return NotFound();

            var updateDto = new BranchEditViewModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Phone = branch.Phone,
                Email = branch.Email,
                IsActive = branch.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BranchEditViewModel BranchEditViewModel)
        {
            if (id != BranchEditViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<BranchEditViewModel, BranchViewModel>($"api/branches/{id}", BranchEditViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(BranchEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _apiService.GetAsync<BranchViewModel>($"api/branches/{id}");
            if (branch == null)
                return NotFound();

            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/branches/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 