using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IPassCompanyService
    {
        Task<IEnumerable<PassCompanyDto>> GetAllAsync();
        Task<PassCompanyDto> GetByIdAsync(int id);
        Task<PassCompanyDto> CreateAsync(CreatePassCompanyDto createDto);
        Task<PassCompanyDto> UpdateAsync(UpdatePassCompanyDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<PassCompanyDto>> GetActiveAsync();
    }
} 