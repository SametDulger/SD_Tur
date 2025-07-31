using AutoMapper;
using SDTur.Application.DTOs.Master.Nationality;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class NationalityService : INationalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NationalityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NationalityDto>> GetAllAsync()
        {
            var nationalities = await _unitOfWork.Nationalities.GetAllAsync();
            return _mapper.Map<IEnumerable<NationalityDto>>(nationalities);
        }

        public async Task<IEnumerable<NationalityDto>> GetActiveAsync()
        {
            var nationalities = await _unitOfWork.Nationalities.GetActiveNationalitiesAsync();
            return _mapper.Map<IEnumerable<NationalityDto>>(nationalities);
        }

        public async Task<NationalityDto> GetByIdAsync(int id)
        {
            var nationality = await _unitOfWork.Nationalities.GetByIdAsync(id);
            return _mapper.Map<NationalityDto>(nationality);
        }

        public async Task<NationalityDto> CreateAsync(CreateNationalityDto createDto)
        {
            var nationality = _mapper.Map<Nationality>(createDto);
            nationality.IsActive = true;
            
            await _unitOfWork.Nationalities.AddAsync(nationality);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<NationalityDto>(nationality);
        }

        public async Task<NationalityDto> UpdateAsync(UpdateNationalityDto updateDto)
        {
            var nationality = await _unitOfWork.Nationalities.GetByIdAsync(updateDto.Id);
            if (nationality == null)
                return null;

            _mapper.Map(updateDto, nationality);
            await _unitOfWork.Nationalities.UpdateAsync(nationality);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<NationalityDto>(nationality);
        }

        public async Task DeleteAsync(int id)
        {
            var nationality = await _unitOfWork.Nationalities.GetByIdAsync(id);
            if (nationality == null)
                return;

            await _unitOfWork.Nationalities.DeleteAsync(nationality.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 