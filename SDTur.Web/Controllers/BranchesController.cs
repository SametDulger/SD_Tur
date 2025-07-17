using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
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
            var branches = await _apiService.GetAsync<IEnumerable<BranchDto>>("api/branches");
            return View(branches);
        }

        public async Task<IActionResult> Details(int id)
        {
            var branch = await _apiService.GetAsync<BranchDto>($"api/branches/{id}");
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
        public async Task<IActionResult> Create([Bind("Name,Address,Phone,Email,IsActive")] CreateBranchDto createBranchDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateBranchDto, BranchDto>("api/branches", createBranchDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createBranchDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var branch = await _apiService.GetAsync<BranchDto>($"api/branches/{id}");
            if (branch == null)
                return NotFound();

            var updateDto = new UpdateBranchDto
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
        public async Task<IActionResult> Edit(int id, UpdateBranchDto updateBranchDto)
        {
            if (id != updateBranchDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateBranchDto, BranchDto>($"api/branches/{id}", updateBranchDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateBranchDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _apiService.GetAsync<BranchDto>($"api/branches/{id}");
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