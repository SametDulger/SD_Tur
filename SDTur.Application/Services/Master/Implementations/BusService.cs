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

        public async Task<BusDto?> GetBusByIdAsync(int id)
        {
            var bus = await _unitOfWork.Buses.GetByIdAsync(id);
            return bus != null ? _mapper.Map<BusDto>(bus) : null;
        }

        public async Task<IEnumerable<BusDto>> GetAvailableBusesAsync()
        {
            var buses = await _unitOfWork.Buses.GetAvailableBusesAsync();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public async Task<BusDto?> CreateAsync(CreateBusDto createDto)
        {
            var entity = _mapper.Map<Bus>(createDto);
            var created = await _unitOfWork.Buses.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BusDto>(created);
        }

        public async Task<BusDto?> UpdateAsync(UpdateBusDto updateDto)
        {
            var entity = await _unitOfWork.Buses.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Buses.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BusDto>(updated);
        }

        public async Task DeleteBusAsync(int id)
        {
            await _unitOfWork.Buses.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 