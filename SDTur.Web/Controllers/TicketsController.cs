using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IApiService _apiService;

        public TicketsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _apiService.GetTicketsAsync();
            return View(tickets);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _apiService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCreateViewModel TicketCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.CreateTicketAsync(TicketCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(TicketCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _apiService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            var updateDto = new TicketEditViewModel
            {
                Id = ticket.Id,
                CustomerName = ticket.CustomerName,
                CustomerEmail = ticket.CustomerEmail,
                CustomerPhone = ticket.CustomerPhone
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketEditViewModel updateTicketViewModel)
        {
            if (id != updateTicketViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.UpdateTicketAsync(updateTicketViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(updateTicketViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _apiService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var ticket = await _apiService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            await _apiService.CancelTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchByDate(DateTime tourDate)
        {
            var tickets = await _apiService.GetTicketsByTourDateAsync(tourDate);
            return View("Index", tickets);
        }

        public async Task<IActionResult> PassTickets()
        {
            var tickets = await _apiService.GetPassTicketsAsync();
            return View(tickets);
        }
    }
} 
