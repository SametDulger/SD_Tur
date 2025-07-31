using AutoMapper;
using SDTur.Application.DTOs.Master.Bus;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class BusService : IBusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusDto>> GetAllBusesAsync()
        {
            var buses = await _unitOfWork.Buses.GetAllAsync();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public async Task<IEnumerable<BusDto>> GetActiveBusesAsync()
        {
            var buses = await _unitOfWork.Buses.GetActiveBusesAsync();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public async Task<BusDto> GetBusByIdAsync(int id)
        {
            var bus = await _unitOfWork.Buses.GetByIdAsync(id);
            return _mapper.Map<BusDto>(bus);
        }

        public async Task<IEnumerable<BusDto>> GetAvailableBusesAsync()
        {
            var buses = await _unitOfWork.Buses.GetAvailableBusesAsync();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public async Task<BusDto> CreateBusAsync(CreateBusDto createBusDto)
        {
            var bus = _mapper.Map<Bus>(createBusDto);
            bus.IsActive = true;
            
            var createdBus = await _unitOfWork.Buses.AddAsync(bus);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BusDto>(createdBus);
        }

        public async Task<BusDto> UpdateBusAsync(UpdateBusDto updateBusDto)
        {
            var existingBus = await _unitOfWork.Buses.GetByIdAsync(updateBusDto.Id);
            if (existingBus == null)
                return null;

            _mapper.Map(updateBusDto, existingBus);
            
            var updatedBus = await _unitOfWork.Buses.UpdateAsync(existingBus);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BusDto>(updatedBus);
        }

        public async Task DeleteBusAsync(int id)
        {
            await _unitOfWork.Buses.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 