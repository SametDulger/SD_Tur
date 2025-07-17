using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class TourReportRepository : Repository<TourReport>, ITourReportRepository
    {
        public TourReportRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourReport>> GetByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.TourSchedule.TourId == tourId && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourReport>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.StartDate >= startDate && tr.EndDate <= endDate && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourReport>> GetByReportTypeAsync(string reportType)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.ReportType == reportType && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourReport>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.Status == status && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<TourReport> GetLatestByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.TourSchedule.TourId == tourId && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TourReport>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .Where(tr => tr.EmployeeId == employeeId && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }
    }
} 