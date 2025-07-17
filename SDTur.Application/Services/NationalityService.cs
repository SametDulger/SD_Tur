using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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
                throw new ArgumentException("Uyruk bulunamadı");

            _mapper.Map(updateDto, nationality);
            
            await _unitOfWork.Nationalities.UpdateAsync(nationality);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<NationalityDto>(nationality);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Nationalities.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 