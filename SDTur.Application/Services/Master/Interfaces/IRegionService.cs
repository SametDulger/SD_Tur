using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Region;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDto>> GetAllRegionsAsync();
        Task<IEnumerable<RegionDto>> GetActiveRegionsAsync();
        Task<RegionDto> GetRegionByIdAsync(int id);
        Task<RegionDto> CreateRegionAsync(CreateRegionDto createRegionDto);
        Task<RegionDto> UpdateRegionAsync(UpdateRegionDto updateRegionDto);
        Task DeleteRegionAsync(int id);
    }
} 