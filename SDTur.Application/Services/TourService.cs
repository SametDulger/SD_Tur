using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<TourDto> GetTourByIdAsync(int id)
        {
            var tour = await _unitOfWork.Tours.GetByIdAsync(id);
            return _mapper.Map<TourDto>(tour);
        }

        public async Task<TourDto> CreateTourAsync(CreateTourDto createTourDto)
        {
            var tour = _mapper.Map<Tour>(createTourDto);
            tour.IsActive = true;
            
            var createdTour = await _unitOfWork.Tours.AddAsync(tour);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourDto>(createdTour);
        }

        public async Task<TourDto> UpdateTourAsync(UpdateTourDto updateTourDto)
        {
            var existingTour = await _unitOfWork.Tours.GetByIdAsync(updateTourDto.Id);
            if (existingTour == null)
                return null;

            _mapper.Map(updateTourDto, existingTour);
            var updatedTour = await _unitOfWork.Tours.UpdateAsync(existingTour);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourDto>(updatedTour);
        }

        public async Task DeleteTourAsync(int id)
        {
            await _unitOfWork.Tours.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 