using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.Ticket;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task<TicketDto?> GetTicketByIdAsync(int id);
        Task<TicketDto?> GetTicketByNumberAsync(string ticketNumber);
        Task<IEnumerable<TicketDto>> GetTicketsByTourDateAsync(DateTime tourDate);
        Task<IEnumerable<TicketDto>> GetTicketsByBranchAsync(int branchId);
        Task<IEnumerable<TicketDto>> GetPassTicketsAsync();
        Task<TicketDto?> CreateAsync(CreateTicketDto createDto);
        Task<TicketDto?> UpdateAsync(UpdateTicketDto updateDto);
        Task CancelTicketAsync(int id);
        Task<string> GenerateTicketNumberAsync();
    }
} 