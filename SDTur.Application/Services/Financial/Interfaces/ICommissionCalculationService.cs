using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.CommissionCalculation;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface ICommissionCalculationService
    {
        Task<IEnumerable<CommissionCalculationDto>> GetAllAsync();
        Task<CommissionCalculationDto?> GetByIdAsync(int id);
        Task<IEnumerable<CommissionCalculationDto>> GetByTicketAsync(int ticketId);
        Task<IEnumerable<CommissionCalculationDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<CommissionCalculationDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CommissionCalculationDto>> GetByStatusAsync(string status);
        Task<decimal> GetTotalCommissionByEmployeeAsync(int employeeId);
        Task<CommissionCalculationDto?> CreateAsync(CreateCommissionCalculationDto createDto);
        Task<CommissionCalculationDto?> UpdateAsync(UpdateCommissionCalculationDto updateDto);
        Task DeleteAsync(int id);
    }
} 