using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionDto>> GetAllRegionsAsync()
        {
            var regions = await _unitOfWork.Regions.GetAllAsync();
            return _mapper.Map<IEnumerable<RegionDto>>(regions);
        }

        public async Task<IEnumerable<RegionDto>> GetActiveRegionsAsync()
        {
            var regions = await _unitOfWork.Regions.GetActiveRegionsAsync();
            return _mapper.Map<IEnumerable<RegionDto>>(regions);
        }

        public async Task<RegionDto> GetRegionByIdAsync(int id)
        {
            var region = await _unitOfWork.Regions.GetByIdAsync(id);
            return _mapper.Map<RegionDto>(region);
        }

        public async Task<RegionDto> CreateRegionAsync(CreateRegionDto createRegionDto)
        {
            var region = _mapper.Map<Region>(createRegionDto);
            region.IsActive = true;
            
            var createdRegion = await _unitOfWork.Regions.AddAsync(region);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<RegionDto>(createdRegion);
        }

        public async Task<RegionDto> UpdateRegionAsync(UpdateRegionDto updateRegionDto)
        {
            var existingRegion = await _unitOfWork.Regions.GetByIdAsync(updateRegionDto.Id);
            if (existingRegion == null)
                return null;

            _mapper.Map(updateRegionDto, existingRegion);
            
            var updatedRegion = await _unitOfWork.Regions.UpdateAsync(existingRegion);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<RegionDto>(updatedRegion);
        }

        public async Task DeleteRegionAsync(int id)
        {
            await _unitOfWork.Regions.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 