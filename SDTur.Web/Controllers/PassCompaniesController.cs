using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Master.Pass;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class PassCompaniesController : Controller
    {
        private readonly IApiService _apiService;

        public PassCompaniesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var passCompanies = await _apiService.GetAsync<List<PassCompanyViewModel>>("api/passcompanies");
            return View(passCompanies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var passCompany = await _apiService.GetAsync<PassCompanyViewModel>($"api/passcompanies/{id}");
            if (passCompany == null)
                return NotFound();

            return View(passCompany);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ContactPerson,Phone,Email,Address,IsActive")] PassCompanyCreateViewModel PassCompanyCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<PassCompanyCreateViewModel, PassCompanyViewModel>("api/passcompanies", PassCompanyCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(PassCompanyCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var passCompany = await _apiService.GetAsync<PassCompanyViewModel>($"api/passcompanies/{id}");
            if (passCompany == null)
                return NotFound();

            var updateDto = new PassCompanyEditViewModel
            {
                Id = passCompany.Id,
                Name = passCompany.Name,
                ContactPerson = passCompany.ContactPerson,
                Phone = passCompany.Phone,
                Email = passCompany.Email,
                Address = passCompany.Address,
                IsActive = passCompany.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PassCompanyEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<PassCompanyEditViewModel, PassCompanyViewModel>($"api/passcompanies/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var passCompany = await _apiService.GetAsync<PassCompanyViewModel>($"api/passcompanies/{id}");
            if (passCompany == null)
                return NotFound();

            return View(passCompany);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/passcompanies/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
