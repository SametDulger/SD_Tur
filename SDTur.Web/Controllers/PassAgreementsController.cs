using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class PassAgreementsController : Controller
    {
        private readonly IApiService _apiService;

        public PassAgreementsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var passAgreements = await _apiService.GetAsync<List<PassAgreementDto>>("api/passagreements");
            return View(passAgreements);
        }

        public async Task<IActionResult> Details(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementDto>($"api/passagreements/{id}");
            if (passAgreement == null)
                return NotFound();

            return View(passAgreement);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassCompanyId,TourId,OutgoingFullPrice,OutgoingHalfPrice,IncomingFullPrice,IncomingHalfPrice,Currency")] CreatePassAgreementDto createDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreatePassAgreementDto, PassAgreementDto>("api/passagreements", createDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementDto>($"api/passagreements/{id}");
            if (passAgreement == null)
                return NotFound();

            var updateDto = new UpdatePassAgreementDto
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassCompanyId,TourId,OutgoingFullPrice,OutgoingHalfPrice,IncomingFullPrice,IncomingHalfPrice,Currency,IsActive")] UpdatePassAgreementDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdatePassAgreementDto, PassAgreementDto>($"api/passagreements/{id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var passAgreement = await _apiService.GetAsync<PassAgreementDto>($"api/passagreements/{id}");
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