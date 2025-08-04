using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Master.Pass;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class PassAgreementsController : Controller
    {
        private readonly IApiService _apiService;

        public PassAgreementsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var passAgreements = await _apiService.GetAsync<List<PassAgreementViewModel>>("api/passagreements");
            return View(passAgreements);
        }

        public async Task<IActionResult> Details(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementViewModel>($"api/passagreements/{id}");
            if (passAgreement == null)
                return NotFound();

            return View(passAgreement);
        }

        public async Task<IActionResult> Create()
        {
            var passCompanies = await _apiService.GetAsync<List<PassCompanyViewModel>>("api/passcompanies");
            ViewBag.PassCompanies = passCompanies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassCompanyId,TourId,OutgoingFullPrice,OutgoingHalfPrice,IncomingFullPrice,IncomingHalfPrice,Currency")] PassAgreementCreateViewModel createDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<PassAgreementCreateViewModel, PassAgreementViewModel>("api/passagreements", createDto);
                return RedirectToAction(nameof(Index));
            }
            
            var passCompanies = await _apiService.GetAsync<List<PassCompanyViewModel>>("api/passcompanies");
            ViewBag.PassCompanies = passCompanies;
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementViewModel>($"api/passagreements/{id}");
            if (passAgreement == null)
                return NotFound();

            var passCompanies = await _apiService.GetAsync<List<PassCompanyViewModel>>("api/passcompanies");
            ViewBag.PassCompanies = passCompanies;

            var updateDto = new PassAgreementEditViewModel
            {
                Id = passAgreement.Id,
                PassCompanyId = passAgreement.PassCompanyId,
                TourId = passAgreement.TourId,
                OutgoingFullPrice = passAgreement.OutgoingFullPrice,
                OutgoingHalfPrice = passAgreement.OutgoingHalfPrice,
                IncomingFullPrice = passAgreement.IncomingFullPrice,
                IncomingHalfPrice = passAgreement.IncomingHalfPrice,
                Currency = passAgreement.Currency,
                IsActive = passAgreement.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassCompanyId,TourId,OutgoingFullPrice,OutgoingHalfPrice,IncomingFullPrice,IncomingHalfPrice,Currency,IsActive")] PassAgreementEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<PassAgreementEditViewModel, PassAgreementViewModel>($"api/passagreements/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            
            var passCompanies = await _apiService.GetAsync<List<PassCompanyViewModel>>("api/passcompanies");
            ViewBag.PassCompanies = passCompanies;
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementViewModel>($"api/passagreements/{id}");
            if (passAgreement == null)
                return NotFound();

            return View(passAgreement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/passagreements/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
