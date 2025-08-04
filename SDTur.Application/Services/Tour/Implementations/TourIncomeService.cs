using AutoMapper;
using SDTur.Application.DTOs.Tour.TourIncome;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourIncomeService : ITourIncomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourIncomeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourIncomeDto>> GetAllAsync()
        {
            var tourIncomes = await _unitOfWork.TourIncomes.GetAllAsync();
            return _mapper.Map<IEnumerable<TourIncomeDto>>(tourIncomes);
        }

        public async Task<TourIncomeDto?> GetByIdAsync(int id)
        {
            var tourIncome = await _unitOfWork.TourIncomes.GetByIdAsync(id);
            return tourIncome != null ? _mapper.Map<TourIncomeDto>(tourIncome) : null;
        }

        public async Task<TourIncomeDto?> CreateAsync(CreateTourIncomeDto createDto)
        {
            var entity = _mapper.Map<TourIncome>(createDto);
            var created = await _unitOfWork.TourIncomes.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourIncomeDto>(created);
        }

        public async Task<TourIncomeDto?> UpdateAsync(UpdateTourIncomeDto updateDto)
        {
            var entity = await _unitOfWork.TourIncomes.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.TourIncomes.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourIncomeDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourIncomes.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourIncomeDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var tourIncomes = await _unitOfWork.TourIncomes.GetIncomesByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<TourIncomeDto>>(tourIncomes);
        }
    }
} 