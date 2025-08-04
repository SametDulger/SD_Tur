using AutoMapper;
using SDTur.Application.DTOs.Financial.CommissionCalculation;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class CommissionCalculationService : ICommissionCalculationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommissionCalculationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommissionCalculationDto>> GetAllAsync()
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetAllAsync();
            return _mapper.Map<IEnumerable<CommissionCalculationDto>>(commissionCalculations);
        }

        public async Task<CommissionCalculationDto?> GetByIdAsync(int id)
        {
            var commissionCalculation = await _unitOfWork.CommissionCalculations.GetByIdAsync(id);
            return commissionCalculation != null ? _mapper.Map<CommissionCalculationDto>(commissionCalculation) : null;
        }

        public async Task<IEnumerable<CommissionCalculationDto>> GetByEmployeeAsync(int employeeId)
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetByEmployeeAsync(employeeId);
            return _mapper.Map<IEnumerable<CommissionCalculationDto>>(commissionCalculations);
        }

        public async Task<IEnumerable<CommissionCalculationDto>> GetByTicketAsync(int ticketId)
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetByTicketAsync(ticketId);
            return _mapper.Map<IEnumerable<CommissionCalculationDto>>(commissionCalculations);
        }

        public async Task<IEnumerable<CommissionCalculationDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<CommissionCalculationDto>>(commissionCalculations);
        }

        public async Task<IEnumerable<CommissionCalculationDto>> GetByStatusAsync(string status)
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<CommissionCalculationDto>>(commissionCalculations);
        }

        public async Task<decimal> GetTotalCommissionByEmployeeAsync(int employeeId)
        {
            var commissionCalculations = await _unitOfWork.CommissionCalculations.GetByEmployeeAsync(employeeId);
            return commissionCalculations.Sum(c => c.CommissionAmount);
        }

        public async Task<CommissionCalculationDto?> CreateAsync(CreateCommissionCalculationDto createDto)
        {
            var entity = _mapper.Map<CommissionCalculation>(createDto);
            var created = await _unitOfWork.CommissionCalculations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CommissionCalculationDto>(created);
        }

        public async Task<CommissionCalculationDto?> UpdateAsync(UpdateCommissionCalculationDto updateDto)
        {
            var entity = await _unitOfWork.CommissionCalculations.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.CommissionCalculations.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CommissionCalculationDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CommissionCalculations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 