using AutoMapper;
using SDTur.Application.DTOs.Tour.BusAssignment;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class BusAssignmentService : IBusAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusAssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusAssignmentDto>> GetAllAsync()
        {
            var busAssignments = await _unitOfWork.BusAssignments.GetAllAsync();
            return _mapper.Map<IEnumerable<BusAssignmentDto>>(busAssignments);
        }

        public async Task<BusAssignmentDto?> GetByIdAsync(int id)
        {
            var busAssignment = await _unitOfWork.BusAssignments.GetByIdAsync(id);
            return busAssignment != null ? _mapper.Map<BusAssignmentDto>(busAssignment) : null;
        }

        public async Task<IEnumerable<BusAssignmentDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var busAssignments = await _unitOfWork.BusAssignments.GetByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<BusAssignmentDto>>(busAssignments);
        }

        public async Task<IEnumerable<BusAssignmentDto>> GetByBusAsync(int busId)
        {
            var busAssignments = await _unitOfWork.BusAssignments.GetByBusAsync(busId);
            return _mapper.Map<IEnumerable<BusAssignmentDto>>(busAssignments);
        }

        public async Task<IEnumerable<BusAssignmentDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var busAssignments = await _unitOfWork.BusAssignments.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<BusAssignmentDto>>(busAssignments);
        }

        public async Task<IEnumerable<BusAssignmentDto>> GetByStatusAsync(string status)
        {
            var busAssignments = await _unitOfWork.BusAssignments.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<BusAssignmentDto>>(busAssignments);
        }

        public async Task<BusAssignmentDto?> CreateAsync(CreateBusAssignmentDto createDto)
        {
            var entity = _mapper.Map<BusAssignment>(createDto);
            var created = await _unitOfWork.BusAssignments.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BusAssignmentDto>(created);
        }

        public async Task<BusAssignmentDto?> UpdateAsync(UpdateBusAssignmentDto updateDto)
        {
            var entity = await _unitOfWork.BusAssignments.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.BusAssignments.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BusAssignmentDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var busAssignment = await _unitOfWork.BusAssignments.GetByIdAsync(id);
            if (busAssignment == null)
                return;

            await _unitOfWork.BusAssignments.DeleteAsync(busAssignment.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 