using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<TourExpenseDto> GetByIdAsync(int id)
        {
            var tourExpense = await _unitOfWork.TourExpenses.GetByIdAsync(id);
            return _mapper.Map<TourExpenseDto>(tourExpense);
        }

        public async Task<TourExpenseDto> CreateAsync(CreateTourExpenseDto createDto)
        {
            var tourExpense = _mapper.Map<TourExpense>(createDto);
            tourExpense.IsActive = true;
            
            await _unitOfWork.TourExpenses.AddAsync(tourExpense);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourExpenseDto>(tourExpense);
        }

        public async Task<TourExpenseDto> UpdateAsync(UpdateTourExpenseDto updateDto)
        {
            var tourExpense = await _unitOfWork.TourExpenses.GetByIdAsync(updateDto.Id);
            if (tourExpense == null)
                throw new ArgumentException("Tur gideri bulunamadı");

            _mapper.Map(updateDto, tourExpense);
            
            await _unitOfWork.TourExpenses.UpdateAsync(tourExpense);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourExpenseDto>(tourExpense);
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