using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class FinancialReportRepository : Repository<FinancialReport>, IFinancialReportRepository
    {
        public FinancialReportRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FinancialReport>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .Where(fr => fr.StartDate >= startDate && fr.EndDate <= endDate && !fr.IsDeleted)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByReportTypeAsync(string reportType)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .Where(fr => fr.ReportType == reportType && !fr.IsDeleted)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .Where(fr => fr.Status == status && !fr.IsDeleted)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<FinancialReport> GetLatestByTypeAsync(string reportType)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .Where(fr => fr.ReportType == reportType && !fr.IsDeleted)
                .OrderByDescending(fr => fr.ReportDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .Where(fr => fr.EmployeeId == employeeId && !fr.IsDeleted)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }
    }
} 