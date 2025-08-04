using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class CommissionCalculationsController : Controller
    {
        private readonly IApiService _apiService;

        public CommissionCalculationsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var commissionCalculations = await _apiService.GetCommissionCalculationsAsync();
                return View(commissionCalculations);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplamaları yüklenirken hata oluştu: " + ex.Message;
                return View(new List<CommissionCalculationViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var commissionCalculation = await _apiService.GetCommissionCalculationByIdAsync(id);
                if (commissionCalculation == null)
                {
                    TempData["Error"] = "Komisyon hesaplaması bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(commissionCalculation);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;
                
                return View(new CommissionCalculationCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommissionCalculationCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateCommissionCalculationAsync(createViewModel);
                    TempData["Success"] = "Komisyon hesaplaması başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması oluşturulurken hata oluştu: " + ex.Message;
                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var commissionCalculation = await _apiService.GetCommissionCalculationByIdAsync(id);
                if (commissionCalculation == null)
                {
                    TempData["Error"] = "Komisyon hesaplaması bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;

                var editViewModel = new CommissionCalculationEditViewModel
                {
                    Id = commissionCalculation.Id,
                    EmployeeId = commissionCalculation.EmployeeId,
                    TicketId = commissionCalculation.TicketId,
                    TourScheduleId = commissionCalculation.TourScheduleId,
                    CommissionAmount = commissionCalculation.CommissionAmount,
                    CommissionRate = commissionCalculation.CommissionRate,
                    CalculationDate = commissionCalculation.CalculationDate,
                    Currency = commissionCalculation.Currency,
                    IsActive = commissionCalculation.IsActive
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması düzenleme sayfası yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CommissionCalculationEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateCommissionCalculationAsync(updateViewModel);
                    TempData["Success"] = "Komisyon hesaplaması başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması güncellenirken hata oluştu: " + ex.Message;
                var employees = await _apiService.GetEmployeesAsync();
                var tourSchedules = await _apiService.GetTourSchedulesAsync();
                var tickets = await _apiService.GetTicketsAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.Employees = employees;
                ViewBag.TourSchedules = tourSchedules;
                ViewBag.Tickets = tickets;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var commissionCalculation = await _apiService.GetCommissionCalculationByIdAsync(id);
                if (commissionCalculation == null)
                {
                    TempData["Error"] = "Komisyon hesaplaması bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(commissionCalculation);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması silme sayfası yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteCommissionCalculationAsync(id);
                TempData["Success"] = "Komisyon hesaplaması başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Komisyon hesaplaması silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
