using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ITourOperationRepository : IRepository<TourOperation>
    {
        Task<IEnumerable<TourOperation>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourOperation>> GetByOperationTypeAsync(string operationType);
        Task<IEnumerable<TourOperation>> GetByStatusAsync(string status);
        Task<TourOperation> GetWithDetailsAsync(int id);
    }
} 