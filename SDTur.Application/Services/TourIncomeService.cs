using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<TourIncomeDto> GetByIdAsync(int id)
        {
            var tourIncome = await _unitOfWork.TourIncomes.GetByIdAsync(id);
            return _mapper.Map<TourIncomeDto>(tourIncome);
        }

        public async Task<TourIncomeDto> CreateAsync(CreateTourIncomeDto createDto)
        {
            var tourIncome = _mapper.Map<TourIncome>(createDto);
            tourIncome.IsActive = true;
            
            await _unitOfWork.TourIncomes.AddAsync(tourIncome);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourIncomeDto>(tourIncome);
        }

        public async Task<TourIncomeDto> UpdateAsync(UpdateTourIncomeDto updateDto)
        {
            var tourIncome = await _unitOfWork.TourIncomes.GetByIdAsync(updateDto.Id);
            if (tourIncome == null)
                throw new ArgumentException("Tur geliri bulunamadı");

            _mapper.Map(updateDto, tourIncome);
            
            await _unitOfWork.TourIncomes.UpdateAsync(tourIncome);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourIncomeDto>(tourIncome);
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