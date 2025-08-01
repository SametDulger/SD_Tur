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
                var invoiceDetails = await _apiService.GetAsync<IEnumerable<InvoiceDetailViewModel>>("api/invoicedetails");
                return View(invoiceDetails);
            }
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetAsync<InvoiceDetailViewModel>($"api/invoicedetails/{id}");
                if (invoiceDetail == null)
                    return NotFound();

                return View(invoiceDetail);
            }
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDetailCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdInvoiceDetail = await _apiService.PostAsync<InvoiceDetailCreateViewModel, InvoiceDetailViewModel>("api/invoicedetails", model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Log the exception
                    ModelState.AddModelError("", "Fatura detayı oluşturulurken bir hata oluştu.");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetAsync<InvoiceDetailViewModel>($"api/invoicedetails/{id}");
                if (invoiceDetail == null)
                    return NotFound();

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
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceDetailEditViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedInvoiceDetail = await _apiService.PutAsync<InvoiceDetailEditViewModel, InvoiceDetailViewModel>($"api/invoicedetails/{id}", model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Log the exception
                    ModelState.AddModelError("", "Fatura detayı güncellenirken bir hata oluştu.");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var invoiceDetail = await _apiService.GetAsync<InvoiceDetailViewModel>($"api/invoicedetails/{id}");
                if (invoiceDetail == null)
                    return NotFound();

                return View(invoiceDetail);
            }
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteAsync($"api/invoicedetails/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }

        public async Task<IActionResult> ByInvoice(int invoiceId)
        {
            try
            {
                var invoiceDetails = await _apiService.GetAsync<IEnumerable<InvoiceDetailViewModel>>($"api/invoicedetails/invoice/{invoiceId}");
                return View("Index", invoiceDetails);
            }
            catch (Exception)
            {
                // Log the exception
                return View("Error");
            }
        }
    }
} 
