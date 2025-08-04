using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class NationalitiesController : Controller
    {
        private readonly IApiService _apiService;

        public NationalitiesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var nationalities = await _apiService.GetAsync<List<NationalityViewModel>>("api/nationalities");
            return View(nationalities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityViewModel>($"api/nationalities/{id}");
            if (nationality == null)
                return NotFound();

            return View(nationality);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Code,IsActive")] NationalityCreateViewModel NationalityCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<NationalityCreateViewModel, NationalityViewModel>("api/nationalities", NationalityCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(NationalityCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityViewModel>($"api/nationalities/{id}");
            if (nationality == null)
                return NotFound();

            var updateDto = new NationalityEditViewModel
            {
                Id = nationality.Id,
                Name = nationality.Name,
                Code = nationality.Code,
                IsActive = nationality.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NationalityEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<NationalityEditViewModel, NationalityViewModel>($"api/nationalities/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityViewModel>($"api/nationalities/{id}");
            if (nationality == null)
                return NotFound();

            return View(nationality);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/nationalities/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
