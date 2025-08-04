using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Financial.Cash;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class CashController : Controller
    {
        private readonly IApiService _apiService;

        public CashController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var cashTransactions = await _apiService.GetCashAsync();
                return View(cashTransactions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemleri yüklenirken hata oluştu: " + ex.Message;
                return View(new List<CashViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var cashTransaction = await _apiService.GetCashByIdAsync(id);
                if (cashTransaction == null)
                {
                    TempData["Error"] = "Nakit işlemi bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(cashTransaction);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;
                
                return View(new CashCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CashCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateCashAsync(createViewModel);
                    TempData["Success"] = "Nakit işlemi başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;
                
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi oluşturulurken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;
                
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var cashTransaction = await _apiService.GetCashByIdAsync(id);
                if (cashTransaction == null)
                {
                    TempData["Error"] = "Nakit işlemi bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;

                var updateViewModel = new CashEditViewModel
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

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CashEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateCashAsync(updateViewModel);
                    TempData["Success"] = "Nakit işlemi başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;
                
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi güncellenirken hata oluştu: " + ex.Message;
                var currencies = await _apiService.GetCurrenciesAsync();
                var employees = await _apiService.GetEmployeesAsync();
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                
                ViewBag.Currencies = currencies;
                ViewBag.Employees = employees;
                ViewBag.PassCompanies = passCompanies;
                
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cashTransaction = await _apiService.GetCashByIdAsync(id);
                if (cashTransaction == null)
                {
                    TempData["Error"] = "Nakit işlemi bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(cashTransaction);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteCashAsync(id);
                TempData["Success"] = "Nakit işlemi başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Nakit işlemi silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
