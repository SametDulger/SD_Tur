using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SDTur.Application.DTOs.Tour.Tour;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourDto>> GetAllToursAsync()
        {
            var tours = await _unitOfWork.Tours.GetAllAsync();
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public async Task<IEnumerable<TourDto>> GetActiveToursAsync()
        {
            var tours = await _unitOfWork.Tours.GetActiveToursAsync();
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public async Task<TourDto?> GetTourByIdAsync(int id)
        {
            var tour = await _unitOfWork.Tours.GetByIdAsync(id);
            return tour != null ? _mapper.Map<TourDto>(tour) : null;
        }

        public async Task<TourDto?> CreateAsync(CreateTourDto createDto)
        {
            var entity = _mapper.Map<SDTur.Core.Entities.Tour.Tour>(createDto);
            var created = await _unitOfWork.Tours.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourDto>(created);
        }

        public async Task<TourDto?> UpdateAsync(UpdateTourDto updateDto)
        {
            var entity = await _unitOfWork.Tours.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Tours.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourDto>(updated);
        }

        public async Task DeleteTourAsync(int id)
        {
            await _unitOfWork.Tours.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 