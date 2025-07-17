using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ITourIncomeRepository : IRepository<TourIncome>
    {
        Task<IEnumerable<TourIncome>> GetIncomesByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourIncome>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 