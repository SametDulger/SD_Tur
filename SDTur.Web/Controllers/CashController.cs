using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Cash;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class CashController : Controller
    {
        private readonly IApiService _apiService;

        public CashController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var cashTransactions = await _apiService.GetAsync<List<CashViewModel>>("api/cash");
            return View(cashTransactions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cashTransaction = await _apiService.GetAsync<CashViewModel>($"api/cash/{id}");
            if (cashTransaction == null)
                return NotFound();
            return View(cashTransaction);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CashCreateViewModel createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PostAsync<CashCreateViewModel, CashViewModel>("api/cash", createDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cashTransaction = await _apiService.GetAsync<CashViewModel>($"api/cash/{id}");
            if (cashTransaction == null)
                return NotFound();

            var updateDto = new CashEditViewModel
            {
                Id = cashTransaction.Id,
                TransactionDate = cashTransaction.TransactionDate,
                TransactionType = cashTransaction.TransactionType,
                Amount = cashTransaction.Amount,
                Currency = cashTransaction.Currency,
                Description = cashTransaction.Description,
                Category = cashTransaction.Category,
                IsAutomatic = cashTransaction.IsAutomatic,
                TicketId = cashTransaction.TicketId,
                TourScheduleId = cashTransaction.TourScheduleId,
                EmployeeId = cashTransaction.EmployeeId,
                PassCompanyId = cashTransaction.PassCompanyId
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CashEditViewModel updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<CashEditViewModel, CashViewModel>($"api/cash/{updateDto.Id}", updateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cashTransaction = await _apiService.GetAsync<CashViewModel>($"api/cash/{id}");
            if (cashTransaction == null)
                return NotFound();
            return View(cashTransaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/cash/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
