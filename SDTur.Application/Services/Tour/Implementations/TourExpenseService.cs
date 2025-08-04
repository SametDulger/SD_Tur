using AutoMapper;
using SDTur.Application.DTOs.Tour.TourExpense;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourExpenseService : ITourExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourExpenseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourExpenseDto>> GetAllAsync()
        {
            var tourExpenses = await _unitOfWork.TourExpenses.GetAllAsync();
            return _mapper.Map<IEnumerable<TourExpenseDto>>(tourExpenses);
        }

        public async Task<TourExpenseDto?> GetByIdAsync(int id)
        {
            var tourExpense = await _unitOfWork.TourExpenses.GetByIdAsync(id);
            return tourExpense != null ? _mapper.Map<TourExpenseDto>(tourExpense) : null;
        }

        public async Task<TourExpenseDto?> CreateAsync(CreateTourExpenseDto createDto)
        {
            var entity = _mapper.Map<TourExpense>(createDto);
            var created = await _unitOfWork.TourExpenses.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourExpenseDto>(created);
        }

        public async Task<TourExpenseDto?> UpdateAsync(UpdateTourExpenseDto updateDto)
        {
            var entity = await _unitOfWork.TourExpenses.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.TourExpenses.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourExpenseDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourExpenses.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourExpenseDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var tourExpenses = await _unitOfWork.TourExpenses.GetExpensesByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<TourExpenseDto>>(tourExpenses);
        }
    }
} 