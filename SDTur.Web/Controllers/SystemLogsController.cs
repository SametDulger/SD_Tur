using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class SystemLogsController : Controller
    {
        private readonly IApiService _apiService;

        public SystemLogsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var systemLogs = await _apiService.GetAsync<List<SystemLogDto>>("api/systemlogs");
            return View(systemLogs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogDto>($"api/systemlogs/{id}");
            if (systemLog == null)
                return NotFound();
            return View(systemLog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogLevel,Category,Action,Message,Details,IpAddress,UserAgent,UserId,EmployeeId")] CreateSystemLogDto createSystemLogDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateSystemLogDto, SystemLogDto>("api/systemlogs", createSystemLogDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createSystemLogDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogDto>($"api/systemlogs/{id}");
            if (systemLog == null)
                return NotFound();
            return View(systemLog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogLevel,Category,Action,Message,Details,IpAddress,UserAgent,UserId,EmployeeId,IsActive")] UpdateSystemLogDto updateSystemLogDto)
        {
            if (id != updateSystemLogDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<UpdateSystemLogDto, SystemLogDto>($"api/systemlogs/{id}", updateSystemLogDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateSystemLogDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogDto>($"api/systemlogs/{id}");
            if (systemLog == null)
                return NotFound();
            return View(systemLog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/systemlogs/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 