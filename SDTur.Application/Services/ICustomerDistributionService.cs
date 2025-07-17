using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ICustomerDistributionService
    {
        Task<IEnumerable<CustomerDistributionDto>> GetAllAsync();
        Task<CustomerDistributionDto> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDistributionDto>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<CustomerDistributionDto>> GetByBusAsync(int busId);
        Task<IEnumerable<CustomerDistributionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CustomerDistributionDto>> GetByTicketAsync(int ticketId);
        Task<IEnumerable<CustomerDistributionDto>> GetByStatusAsync(string status);
        Task<CustomerDistributionDto> CreateAsync(CreateCustomerDistributionDto createDto);
        Task<CustomerDistributionDto> UpdateAsync(UpdateCustomerDistributionDto updateDto);
        Task DeleteAsync(int id);
    }
} 