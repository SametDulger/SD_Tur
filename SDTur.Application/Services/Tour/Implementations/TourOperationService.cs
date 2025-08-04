using AutoMapper;
using SDTur.Application.DTOs.Tour.TourOperation;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourOperationService : ITourOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourOperationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourOperationDto>> GetAllAsync()
        {
            var tourOperations = await _unitOfWork.TourOperations.GetAllAsync();
            return _mapper.Map<IEnumerable<TourOperationDto>>(tourOperations);
        }

        public async Task<TourOperationDto?> GetByIdAsync(int id)
        {
            var tourOperation = await _unitOfWork.TourOperations.GetByIdAsync(id);
            return tourOperation != null ? _mapper.Map<TourOperationDto>(tourOperation) : null;
        }

        public async Task<IEnumerable<TourOperationDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var tourOperations = await _unitOfWork.TourOperations.GetByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<TourOperationDto>>(tourOperations);
        }

        public async Task<IEnumerable<TourOperationDto>> GetByOperationTypeAsync(string operationType)
        {
            var tourOperations = await _unitOfWork.TourOperations.GetByOperationTypeAsync(operationType);
            return _mapper.Map<IEnumerable<TourOperationDto>>(tourOperations);
        }

        public async Task<IEnumerable<TourOperationDto>> GetByStatusAsync(string status)
        {
            var tourOperations = await _unitOfWork.TourOperations.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<TourOperationDto>>(tourOperations);
        }

        public async Task<TourOperationDto?> CreateAsync(CreateTourOperationDto createDto)
        {
            var entity = _mapper.Map<TourOperation>(createDto);
            var created = await _unitOfWork.TourOperations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourOperationDto>(created);
        }

        public async Task<TourOperationDto?> UpdateAsync(UpdateTourOperationDto updateDto)
        {
            var entity = await _unitOfWork.TourOperations.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.TourOperations.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourOperationDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourOperations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 