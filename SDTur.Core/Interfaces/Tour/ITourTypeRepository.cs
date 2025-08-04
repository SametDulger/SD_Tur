using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourTypeRepository : IRepository<TourType>
    {
        Task<IEnumerable<TourType>> GetActiveTourTypesAsync();
    }
} 