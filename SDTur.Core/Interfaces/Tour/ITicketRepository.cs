using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket?> GetTicketWithDetailsAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByTourDateAsync(DateTime tourDate);
        Task<IEnumerable<Ticket>> GetTicketsByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<Ticket>> GetTicketsByBranchAsync(int branchId);
        Task<IEnumerable<Ticket>> GetTicketsByHotelAsync(int hotelId);
        Task<IEnumerable<Ticket>> GetPassTicketsAsync();
        Task<IEnumerable<Ticket>> GetPassTicketsByCompanyAsync(string companyName);
        Task<string> GenerateTicketNumberAsync();
        Task<bool> IsTicketNumberExistsAsync(string ticketNumber);
        Task<IEnumerable<Ticket>> GetTicketsForBusAssignmentAsync(int tourScheduleId);
    }
} 