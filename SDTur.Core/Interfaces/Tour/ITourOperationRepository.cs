using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourOperationRepository : IRepository<TourOperation>
    {
        Task<IEnumerable<TourOperation>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourOperation>> GetByOperationTypeAsync(string operationType);
        Task<IEnumerable<TourOperation>> GetByStatusAsync(string status);
        Task<TourOperation> GetWithDetailsAsync(int id);
    }
} 