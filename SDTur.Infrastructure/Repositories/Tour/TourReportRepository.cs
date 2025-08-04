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

        public async Task<TourReport?> GetTourReportWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Include(tr => tr.Employee)
                .FirstOrDefaultAsync(tr => tr.Id == id);
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

        public async Task<IEnumerable<TourReport>> GetReportsByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Where(tr => tr.TourScheduleId == tourScheduleId && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourReport>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Where(tr => tr.ReportDate >= startDate && tr.ReportDate <= endDate && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourReport>> GetReportsByReportTypeAsync(string reportType)
        {
            return await _dbSet
                .Include(tr => tr.TourSchedule)
                .Where(tr => tr.ReportType == reportType && !tr.IsDeleted)
                .OrderByDescending(tr => tr.ReportDate)
                .ToListAsync();
        }
    }
} 