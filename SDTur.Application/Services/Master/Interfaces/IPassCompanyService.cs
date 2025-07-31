using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.PassCompany;

namespace SDTur.Application.Services.Master.Interfaces
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