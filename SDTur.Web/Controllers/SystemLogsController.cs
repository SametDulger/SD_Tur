using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.System.Logs;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class SystemLogsController : Controller
    {
        private readonly IApiService _apiService;

        public SystemLogsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var systemLogs = await _apiService.GetAsync<List<SystemLogViewModel>>("api/systemlogs");
            return View(systemLogs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogViewModel>($"api/systemlogs/{id}");
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
        public async Task<IActionResult> Create([Bind("LogLevel,Category,Action,Message,Details,IpAddress,UserAgent,UserId,EmployeeId")] SystemLogCreateViewModel createSystemLogViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<SystemLogCreateViewModel, SystemLogViewModel>("api/systemlogs", createSystemLogViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createSystemLogViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogViewModel>($"api/systemlogs/{id}");
            if (systemLog == null)
                return NotFound();
            return View(systemLog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogLevel,Category,Action,Message,Details,IpAddress,UserAgent,UserId,EmployeeId,IsActive")] SystemLogEditViewModel SystemLogEditViewModel)
        {
            if (id != SystemLogEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<SystemLogEditViewModel, SystemLogViewModel>($"api/systemlogs/{id}", SystemLogEditViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(SystemLogEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var systemLog = await _apiService.GetAsync<SystemLogViewModel>($"api/systemlogs/{id}");
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
