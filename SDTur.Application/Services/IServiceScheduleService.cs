using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IServiceScheduleService
    {
        Task<IEnumerable<ServiceScheduleDto>> GetAllAsync();
        Task<ServiceScheduleDto> GetByIdAsync(int id);
        Task<ServiceScheduleDto> CreateAsync(CreateServiceScheduleDto createDto);
        Task<ServiceScheduleDto> UpdateAsync(UpdateServiceScheduleDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ServiceScheduleDto>> GetByTourAsync(int tourId);
        Task<IEnumerable<ServiceScheduleDto>> GetByRegionAsync(int regionId);
        Task<IEnumerable<ServiceScheduleDto>> GetByDateAsync(DateTime date);
    }
} 