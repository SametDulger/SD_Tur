using AutoMapper;
using SDTur.Application.DTOs.Master.Region;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
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

        public async Task<RegionDto?> GetRegionByIdAsync(int id)
        {
            var region = await _unitOfWork.Regions.GetByIdAsync(id);
            return region != null ? _mapper.Map<RegionDto>(region) : null;
        }

        public async Task<RegionDto?> CreateAsync(CreateRegionDto createDto)
        {
            var entity = _mapper.Map<Region>(createDto);
            var created = await _unitOfWork.Regions.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RegionDto>(created);
        }

        public async Task<RegionDto?> UpdateAsync(UpdateRegionDto updateDto)
        {
            var entity = await _unitOfWork.Regions.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Regions.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RegionDto>(updated);
        }

        public async Task DeleteRegionAsync(int id)
        {
            await _unitOfWork.Regions.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 