using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IServiceScheduleRepository : IRepository<ServiceSchedule>
    {
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByTourAsync(int tourId);
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByRegionAsync(int regionId);
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByDateAsync(DateTime date);
    }
} 