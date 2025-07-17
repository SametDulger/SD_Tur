using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ITourExpenseRepository : IRepository<TourExpense>
    {
        Task<IEnumerable<TourExpense>> GetExpensesByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourExpense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 