using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly IApiService _apiService;

        public InvoiceDetailsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var invoiceDetails = await _apiService.GetInvoiceDetailsAsync();
                return View(invoiceDetails);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayları yüklenirken hata oluştu: " + ex.Message;
                return View(new List<InvoiceDetailViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetInvoiceDetailByIdAsync(id);
                if (invoiceDetail == null)
                {
                    TempData["Error"] = "Fatura detayı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(invoiceDetail);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;
                return View(new InvoiceDetailCreateViewModel());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sayfa yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDetailCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.CreateInvoiceDetailAsync(model);
                    TempData["Success"] = "Fatura detayı başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                
                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı oluşturulurken hata oluştu: " + ex.Message;
                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetInvoiceDetailByIdAsync(id);
                if (invoiceDetail == null)
                {
                    TempData["Error"] = "Fatura detayı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;

                var editModel = new InvoiceDetailEditViewModel
                {
                    Id = invoiceDetail.Id,
                    InvoiceId = invoiceDetail.InvoiceId,
                    ProductName = invoiceDetail.ProductName,
                    Description = invoiceDetail.Description,
                    Quantity = invoiceDetail.Quantity,
                    UnitPrice = invoiceDetail.UnitPrice,
                    TaxRate = invoiceDetail.TaxRate,
                    IsActive = invoiceDetail.IsActive
                };

                return View(editModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InvoiceDetailEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiService.UpdateInvoiceDetailAsync(model);
                    TempData["Success"] = "Fatura detayı başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                
                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı güncellenirken hata oluştu: " + ex.Message;
                var invoices = await _apiService.GetInvoicesAsync();
                ViewBag.Invoices = invoices;
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetInvoiceDetailByIdAsync(id);
                if (invoiceDetail == null)
                {
                    TempData["Error"] = "Fatura detayı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(invoiceDetail);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteInvoiceDetailAsync(id);
                TempData["Success"] = "Fatura detayı başarıyla silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayı silinirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> ByInvoice(int invoiceId)
        {
            try
            {
                var invoiceDetails = await _apiService.GetInvoiceDetailsByInvoiceIdAsync(invoiceId);
                ViewBag.InvoiceId = invoiceId;
                return View("Index", invoiceDetails);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fatura detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 
