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
    public class TourExpenseRepository : Repository<TourExpense>, ITourExpenseRepository
    {
        public TourExpenseRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourExpense>> GetExpensesByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(te => te.TourScheduleId == tourScheduleId && te.IsActive && !te.IsDeleted)
                .OrderBy(te => te.ExpenseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourExpense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(te => te.ExpenseDate >= startDate && te.ExpenseDate <= endDate && te.IsActive && !te.IsDeleted)
                .OrderBy(te => te.ExpenseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourExpense>> GetExpensesByCategoryAsync(string category)
        {
            return await _dbSet
                .Include(te => te.TourSchedule)
                .Where(te => te.Category == category && te.IsActive && !te.IsDeleted)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalExpensesByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(te => te.TourScheduleId == tourScheduleId && te.IsActive && !te.IsDeleted)
                .SumAsync(te => te.Amount);
        }
    }
} 