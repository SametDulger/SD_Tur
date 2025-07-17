using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
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
        public async Task<IActionResult> Create(CreateTicketDto createTicketDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.CreateTicketAsync(createTicketDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createTicketDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _apiService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            var updateDto = new UpdateTicketDto
            {
                Id = ticket.Id,
                CustomerName = ticket.CustomerName,
                Nationality = ticket.Nationality,
                RoomNumber = ticket.RoomNumber,
                RequiresService = ticket.RequiresService,
                FullCount = ticket.FullCount,
                HalfCount = ticket.HalfCount,
                GuestCount = ticket.GuestCount,
                TotalAmount = ticket.TotalAmount,
                PaidAmount = ticket.PaidAmount,
                Currency = ticket.Currency,
                Notes = ticket.Notes,
                HotelId = ticket.HotelId
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTicketDto updateTicketDto)
        {
            if (id != updateTicketDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _apiService.UpdateTicketAsync(updateTicketDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateTicketDto);
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

        public async Task<IActionResult> Search()
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