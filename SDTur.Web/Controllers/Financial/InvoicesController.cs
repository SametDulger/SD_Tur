using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers.Financial
{
    public class InvoicesController : Controller
    {
        private readonly IApiService _apiService;

        public InvoicesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var invoices = await _apiService.GetAsync<List<InvoiceViewModel>>("api/invoices");
            return View(invoices);
        }

        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _apiService.GetAsync<InvoiceViewModel>($"api/invoices/{id}/details");
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNumber,InvoiceDate,PassCompanyId,TotalAmount,Currency,Status,Notes")] CreateInvoiceViewModel createInvoiceViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<CreateInvoiceViewModel, InvoiceViewModel>("api/invoices", createInvoiceViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createInvoiceViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _apiService.GetAsync<InvoiceViewModel>($"api/invoices/{id}");
            if (invoice == null)
                return NotFound();

            var updateDto = new UpdateInvoiceViewModel
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

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateInvoiceViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UpdateInvoiceViewModel, InvoiceViewModel>($"api/invoices/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _apiService.GetAsync<InvoiceViewModel>($"api/invoices/{id}");
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/invoices/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 