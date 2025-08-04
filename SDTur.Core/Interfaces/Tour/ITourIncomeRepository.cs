using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourIncomeRepository : IRepository<TourIncome>
    {
        Task<IEnumerable<TourIncome>> GetIncomesByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourIncome>> GetIncomesByCategoryAsync(string category);
        Task<decimal> GetTotalIncomesByTourScheduleAsync(int tourScheduleId);
    }
} 