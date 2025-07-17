using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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
            var hotels = await _unitOfWork.Hotels.GetActiveHotelsAsync();
            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<HotelDto> GetHotelByIdAsync(int id)
        {
            var hotel = await _unitOfWork.Hotels.GetHotelWithRegionAsync(id);
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsByRegionAsync(int regionId)
        {
            var hotels = await _unitOfWork.Hotels.GetHotelsByRegionAsync(regionId);
            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<HotelDto> CreateHotelAsync(CreateHotelDto createHotelDto)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDto);
            hotel.IsActive = true;
            
            var createdHotel = await _unitOfWork.Hotels.AddAsync(hotel);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<HotelDto>(createdHotel);
        }

        public async Task<HotelDto> UpdateHotelAsync(UpdateHotelDto updateHotelDto)
        {
            var existingHotel = await _unitOfWork.Hotels.GetByIdAsync(updateHotelDto.Id);
            if (existingHotel == null)
                return null;

            _mapper.Map(updateHotelDto, existingHotel);
            
            var updatedHotel = await _unitOfWork.Hotels.UpdateAsync(existingHotel);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<HotelDto>(updatedHotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _unitOfWork.Hotels.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 