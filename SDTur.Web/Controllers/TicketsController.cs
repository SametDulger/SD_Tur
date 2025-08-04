using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Create()
        {
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
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
            
            var tours = await _apiService.GetAsync<List<TourViewModel>>("api/tours");
            ViewBag.Tours = tours;
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
                Nationality = ticket.Nationality,
                RoomNumber = ticket.RoomNumber,
                RequiresService = ticket.RequiresService,
                FullCount = ticket.FullCount,
                HalfCount = ticket.HalfCount,
                GuestCount = ticket.GuestCount,
                TotalAmount = ticket.TotalAmount,
                PaidAmount = ticket.PaidAmount,
                RestAmount = ticket.RestAmount,
                Currency = ticket.Currency,
                Notes = ticket.Notes,
                IsCancelled = ticket.IsCancelled,
                IsPassTicket = ticket.IsPassTicket,
                IsIncomingPass = ticket.IsIncomingPass,
                SaleDate = ticket.SaleDate,
                CancellationDate = ticket.CancellationDate,
                TourId = ticket.TourId,
                BranchId = ticket.BranchId,
                EmployeeId = ticket.EmployeeId,
                HotelId = ticket.HotelId,
                ServiceScheduleId = ticket.ServiceScheduleId,
                TourScheduleId = ticket.TourScheduleId,
                BusId = ticket.BusId,
                PassCompanyId = ticket.PassCompanyId
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
            var passTickets = await _apiService.GetPassTicketsAsync();
            return View(passTickets);
        }
    }
} 
