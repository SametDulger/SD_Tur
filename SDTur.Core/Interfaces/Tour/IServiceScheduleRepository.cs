using System;
using SDTur.Core.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface IServiceScheduleRepository : IRepository<ServiceSchedule>
    {
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByTourAsync(int tourId);
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByRegionAsync(int regionId);
        Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByDateAsync(DateTime date);
    }
} 