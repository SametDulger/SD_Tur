using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<TourOperationDto> GetByIdAsync(int id)
        {
            var tourOperation = await _unitOfWork.TourOperations.GetByIdAsync(id);
            return _mapper.Map<TourOperationDto>(tourOperation);
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

        public async Task<TourOperationDto> CreateAsync(CreateTourOperationDto createDto)
        {
            var tourOperation = _mapper.Map<TourOperation>(createDto);
            tourOperation.IsActive = true;
            
            await _unitOfWork.TourOperations.AddAsync(tourOperation);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourOperationDto>(tourOperation);
        }

        public async Task<TourOperationDto> UpdateAsync(UpdateTourOperationDto updateDto)
        {
            var tourOperation = await _unitOfWork.TourOperations.GetByIdAsync(updateDto.Id);
            if (tourOperation == null)
                throw new ArgumentException("Tur operasyonu bulunamadı");
            
            _mapper.Map(updateDto, tourOperation);
            
            await _unitOfWork.TourOperations.UpdateAsync(tourOperation);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourOperationDto>(tourOperation);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourOperations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 