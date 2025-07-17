using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ICommissionCalculationService
    {
        Task<IEnumerable<CommissionCalculationDto>> GetAllAsync();
        Task<CommissionCalculationDto> GetByIdAsync(int id);
        Task<IEnumerable<CommissionCalculationDto>> GetByTicketAsync(int ticketId);
        Task<IEnumerable<CommissionCalculationDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<CommissionCalculationDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CommissionCalculationDto>> GetByStatusAsync(string status);
        Task<decimal> GetTotalCommissionByEmployeeAsync(int employeeId);
        Task<CommissionCalculationDto> CreateAsync(CreateCommissionCalculationDto createDto);
        Task<CommissionCalculationDto> UpdateAsync(UpdateCommissionCalculationDto updateDto);
        Task DeleteAsync(int id);
    }
} 