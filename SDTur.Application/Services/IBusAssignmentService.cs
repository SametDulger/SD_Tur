using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IBusAssignmentService
    {
        Task<IEnumerable<BusAssignmentDto>> GetAllAsync();
        Task<BusAssignmentDto> GetByIdAsync(int id);
        Task<IEnumerable<BusAssignmentDto>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<BusAssignmentDto>> GetByBusAsync(int busId);
        Task<IEnumerable<BusAssignmentDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BusAssignmentDto>> GetByStatusAsync(string status);
        Task<BusAssignmentDto> CreateAsync(CreateBusAssignmentDto createDto);
        Task<BusAssignmentDto> UpdateAsync(UpdateBusAssignmentDto updateDto);
        Task DeleteAsync(int id);
    }
} 