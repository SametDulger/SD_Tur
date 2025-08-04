using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Tour;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Tour
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<Ticket?> GetTicketWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Branch)
                .Include(t => t.Employee)
                .Include(t => t.Hotel)
                .Include(t => t.ServiceSchedule)
                .Include(t => t.TourSchedule)
                .Include(t => t.Bus)
                .FirstOrDefaultAsync(t => t.Id == id && t.IsActive && !t.IsDeleted);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByTourDateAsync(DateTime tourDate)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Hotel)
                .Include(t => t.Hotel.Region)
                .Where(t => t.TourDate.Date == tourDate.Date && !t.IsCancelled && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.Hotel.Region.DistanceFromKemer)
                .ThenBy(t => t.Hotel.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Hotel)
                .Include(t => t.Hotel.Region)
                .Where(t => t.TourScheduleId == tourScheduleId && !t.IsCancelled && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.Hotel.Region.DistanceFromKemer)
                .ThenBy(t => t.Hotel.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByBranchAsync(int branchId)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Hotel)
                .Where(t => t.BranchId == branchId && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByHotelAsync(int hotelId)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Branch)
                .Where(t => t.HotelId == hotelId && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetPassTicketsAsync()
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Hotel)
                .Where(t => t.IsPassTicket && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetPassTicketsByCompanyAsync(string companyName)
        {
            return await _dbSet
                .Include(t => t.Tour)
                .Include(t => t.Hotel)
                .Include(t => t.PassCompany)
                .Where(t => t.IsPassTicket && t.PassCompany.Name == companyName && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }

        public async Task<string> GenerateTicketNumberAsync()
        {
            var lastTicket = await _dbSet
                .Where(t => t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.TicketNumber)
                .FirstOrDefaultAsync();

            if (lastTicket == null)
                return "TKT-0001";

            var lastNumber = int.Parse(lastTicket.TicketNumber.Split('-')[1]);
            return $"TKT-{(lastNumber + 1):D4}";
        }

        public async Task<bool> IsTicketNumberExistsAsync(string ticketNumber)
        {
            return await _dbSet.AnyAsync(t => t.TicketNumber == ticketNumber && t.IsActive && !t.IsDeleted);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsForBusAssignmentAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(t => t.Hotel)
                .Include(t => t.Hotel.Region)
                .Where(t => t.TourScheduleId == tourScheduleId && !t.IsCancelled && t.IsActive && !t.IsDeleted)
                .OrderByDescending(t => t.Hotel.Region.DistanceFromKemer)
                .ThenBy(t => t.Hotel.Order)
                .ToListAsync();
        }
    }
} 