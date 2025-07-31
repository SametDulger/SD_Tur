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

        public async Task<CommissionCalculationDto> GetByIdAsync(int id)
        {
            var commissionCalculation = await _unitOfWork.CommissionCalculations.GetByIdAsync(id);
            return _mapper.Map<CommissionCalculationDto>(commissionCalculation);
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

        public async Task<CommissionCalculationDto> CreateAsync(CreateCommissionCalculationDto createDto)
        {
            var commissionCalculation = _mapper.Map<CommissionCalculation>(createDto);
            commissionCalculation.IsActive = true;
            
            await _unitOfWork.CommissionCalculations.AddAsync(commissionCalculation);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CommissionCalculationDto>(commissionCalculation);
        }

        public async Task<CommissionCalculationDto> UpdateAsync(UpdateCommissionCalculationDto updateDto)
        {
            var existingCommissionCalculation = await _unitOfWork.CommissionCalculations.GetByIdAsync(updateDto.Id);
            if (existingCommissionCalculation == null)
                throw new ArgumentException("Commission calculation not found");
            
            _mapper.Map(updateDto, existingCommissionCalculation);
            
            await _unitOfWork.CommissionCalculations.UpdateAsync(existingCommissionCalculation);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CommissionCalculationDto>(existingCommissionCalculation);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CommissionCalculations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 