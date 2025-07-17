using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpGet("number/{ticketNumber}")]
        public async Task<ActionResult<TicketDto>> GetTicketByNumber(string ticketNumber)
        {
            var ticket = await _ticketService.GetTicketByNumberAsync(ticketNumber);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpGet("tour-date/{tourDate:datetime}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsByTourDate(DateTime tourDate)
        {
            var tickets = await _ticketService.GetTicketsByTourDateAsync(tourDate);
            return Ok(tickets);
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsByBranch(int branchId)
        {
            var tickets = await _ticketService.GetTicketsByBranchAsync(branchId);
            return Ok(tickets);
        }

        [HttpGet("pass")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetPassTickets()
        {
            var tickets = await _ticketService.GetPassTicketsAsync();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicket(CreateTicketDto createTicketDto)
        {
            var ticket = await _ticketService.CreateTicketAsync(createTicketDto);
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
            if (id != updateTicketDto.Id)
                return BadRequest();

            var ticket = await _ticketService.UpdateTicketAsync(updateTicketDto);
            if (ticket == null)
                return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelTicket(int id)
        {
            await _ticketService.CancelTicketAsync(id);
            return NoContent();
        }

        [HttpGet("generate-number")]
        public async Task<ActionResult<string>> GenerateTicketNumber()
        {
            var ticketNumber = await _ticketService.GenerateTicketNumberAsync();
            return Ok(ticketNumber);
        }
    }
} 