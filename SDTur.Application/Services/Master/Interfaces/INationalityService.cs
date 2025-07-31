using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Nationality;

namespace SDTur.Application.Services.Master.Interfaces
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