using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class NationalitiesController : Controller
    {
        private readonly IApiService _apiService;

        public NationalitiesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var nationalities = await _apiService.GetAsync<List<NationalityDto>>("api/nationalities");
            return View(nationalities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityDto>($"api/nationalities/{id}");
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
        public async Task<IActionResult> Create([Bind("Name,Code,IsActive")] CreateNationalityDto createNationalityDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateNationalityDto, NationalityDto>("api/nationalities", createNationalityDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createNationalityDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityDto>($"api/nationalities/{id}");
            if (nationality == null)
                return NotFound();

            var updateDto = new UpdateNationalityDto
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
        public async Task<IActionResult> Edit(int id, UpdateNationalityDto updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateNationalityDto, NationalityDto>($"api/nationalities/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var nationality = await _apiService.GetAsync<NationalityDto>($"api/nationalities/{id}");
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