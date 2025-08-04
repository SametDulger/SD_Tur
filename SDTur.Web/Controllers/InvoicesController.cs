using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Financial.Invoices;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly IApiService _apiService;

        public InvoicesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var invoices = await _apiService.GetInvoicesAsync();
                return View(invoices);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Faturalar yüklenirken hata oluştu: " + ex.Message;
                return View(new List<InvoiceViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var invoice = await _apiService.GetInvoiceByIdAsync(id);
                if (invoice == null)
                {
                    TempData["Error"] = "Fatura bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(invoice);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;
                
                return View(new InvoiceCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateInvoiceAsync(createViewModel);
                    TempData["Success"] = "Fatura başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura oluşturulurken hata oluştu: " + ex.Message;
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;
                
                return View(createViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var invoice = await _apiService.GetInvoiceByIdAsync(id);
                if (invoice == null)
                {
                    TempData["Error"] = "Fatura bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;

                var updateViewModel = new InvoiceEditViewModel
                {
                    Id = invoice.Id,
                    InvoiceNumber = invoice.InvoiceNumber,
                    InvoiceDate = invoice.InvoiceDate,
                    PassCompanyId = invoice.PassCompanyId,
                    TotalAmount = invoice.TotalAmount,
                    Currency = invoice.Currency,
                    Status = invoice.Status,
                    Notes = invoice.Notes,
                    IsActive = invoice.IsActive
                };

                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InvoiceEditViewModel updateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateInvoiceAsync(updateViewModel);
                    TempData["Success"] = "Fatura başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura güncellenirken hata oluştu: " + ex.Message;
                var passCompanies = await _apiService.GetPassCompaniesAsync();
                var currencies = await _apiService.GetCurrenciesAsync();
                
                ViewBag.PassCompanies = passCompanies;
                ViewBag.Currencies = currencies;
                
                return View(updateViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var invoice = await _apiService.GetInvoiceByIdAsync(id);
                if (invoice == null)
                {
                    TempData["Error"] = "Fatura bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(invoice);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteInvoiceAsync(id);
                TempData["Success"] = "Fatura başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
