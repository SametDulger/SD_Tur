using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ITourScheduleRepository : IRepository<TourSchedule>
    {
        Task<TourSchedule> GetTourScheduleWithDetailsAsync(int id);
        Task<IEnumerable<TourSchedule>> GetTourSchedulesByTourAsync(int tourId);
        Task<IEnumerable<TourSchedule>> GetTourSchedulesByDateAsync(DateTime date);
    }
} 