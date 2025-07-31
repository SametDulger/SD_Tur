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

        public async Task<HotelDto> GetHotelByIdAsync(int id)
        {
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(id);
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsByRegionAsync(int regionId)
        {
            var hotels = await _unitOfWork.Hotels.GetAllAsync();
            return _mapper.Map<IEnumerable<HotelDto>>(hotels.Where(h => h.RegionId == regionId));
        }

        public async Task<HotelDto> CreateHotelAsync(CreateHotelDto createHotelDto)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDto);
            hotel.IsActive = true;
            
            await _unitOfWork.Hotels.AddAsync(hotel);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<HotelDto> UpdateHotelAsync(UpdateHotelDto updateHotelDto)
        {
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(updateHotelDto.Id);
            if (hotel == null)
                return null;

            _mapper.Map(updateHotelDto, hotel);
            await _unitOfWork.Hotels.UpdateAsync(hotel);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<HotelDto>(hotel);
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