using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Region;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IRegionService
    {
        Task<RegionDto?> CreateAsync(CreateRegionDto createDto);
        Task<RegionDto?> UpdateAsync(UpdateRegionDto updateDto);
        Task<IEnumerable<RegionDto>> GetAllRegionsAsync();
        Task<IEnumerable<RegionDto>> GetActiveRegionsAsync();
        Task<RegionDto?> GetRegionByIdAsync(int id);
        Task DeleteRegionAsync(int id);
    }
} 