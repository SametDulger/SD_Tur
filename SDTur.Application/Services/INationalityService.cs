using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface INationalityService
    {
        Task<IEnumerable<NationalityDto>> GetAllAsync();
        Task<IEnumerable<NationalityDto>> GetActiveAsync();
        Task<NationalityDto> GetByIdAsync(int id);
        Task<NationalityDto> CreateAsync(CreateNationalityDto createDto);
        Task<NationalityDto> UpdateAsync(UpdateNationalityDto updateDto);
        Task DeleteAsync(int id);
    }
} 