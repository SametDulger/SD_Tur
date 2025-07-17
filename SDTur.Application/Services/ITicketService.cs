using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(int id);
        Task<TicketDto> GetTicketByNumberAsync(string ticketNumber);
        Task<IEnumerable<TicketDto>> GetTicketsByTourDateAsync(DateTime tourDate);
        Task<IEnumerable<TicketDto>> GetTicketsByBranchAsync(int branchId);
        Task<IEnumerable<TicketDto>> GetPassTicketsAsync();
        Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto);
        Task<TicketDto> UpdateTicketAsync(UpdateTicketDto updateTicketDto);
        Task CancelTicketAsync(int id);
        Task<string> GenerateTicketNumberAsync();
    }
} 