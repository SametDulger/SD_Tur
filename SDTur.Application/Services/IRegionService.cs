using SDTur.Application.DTOs;

namespace SDTur.Application.Services
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