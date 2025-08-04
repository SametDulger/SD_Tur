using AutoMapper;
using SDTur.Application.DTOs.Master.Hotel;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelDto>> GetAllHotelsAsync()
        {
            var hotels = await _unitOfWork.Hotels.GetAllAsync();
            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<IEnumerable<HotelDto>> GetActiveHotelsAsync()
        {
            var hotels = await _unitOfWork.Hotels.GetAllAsync();
            return _mapper.Map<IEnumerable<HotelDto>>(hotels.Where(h => h.IsActive));
        }

        public async Task<HotelDto?> GetHotelByIdAsync(int id)
        {
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(id);
            return hotel != null ? _mapper.Map<HotelDto>(hotel) : null;
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsByRegionAsync(int regionId)
        {
            var hotels = await _unitOfWork.Hotels.GetAllAsync();
            return _mapper.Map<IEnumerable<HotelDto>>(hotels.Where(h => h.RegionId == regionId));
        }

        public async Task<HotelDto?> CreateAsync(CreateHotelDto createDto)
        {
            var entity = _mapper.Map<Hotel>(createDto);
            var created = await _unitOfWork.Hotels.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HotelDto>(created);
        }

        public async Task<HotelDto?> UpdateAsync(UpdateHotelDto updateDto)
        {
            var entity = await _unitOfWork.Hotels.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Hotels.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HotelDto>(updated);
        }

        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(id);
            if (hotel == null)
                return;

            await _unitOfWork.Hotels.DeleteAsync(hotel.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 