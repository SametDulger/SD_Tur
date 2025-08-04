using AutoMapper;
using SDTur.Application.DTOs.Tour.TourType;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Core.Interfaces.Tour;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourTypeService : ITourTypeService
    {
        private readonly ITourTypeRepository _tourTypeRepository;
        private readonly IMapper _mapper;

        public TourTypeService(ITourTypeRepository tourTypeRepository, IMapper mapper)
        {
            _tourTypeRepository = tourTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourTypeDto>> GetAllAsync()
        {
            var tourTypes = await _tourTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TourTypeDto>>(tourTypes);
        }

        public async Task<IEnumerable<TourTypeDto>> GetActiveAsync()
        {
            var tourTypes = await _tourTypeRepository.GetActiveTourTypesAsync();
            return _mapper.Map<IEnumerable<TourTypeDto>>(tourTypes);
        }

        public async Task<TourTypeDto?> GetByIdAsync(int id)
        {
            var tourType = await _tourTypeRepository.GetByIdAsync(id);
            return _mapper.Map<TourTypeDto>(tourType);
        }
    }
} 