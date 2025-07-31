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

        public async Task<BusAssignmentDto> GetByIdAsync(int id)
        {
            var busAssignment = await _unitOfWork.BusAssignments.GetByIdAsync(id);
            return _mapper.Map<BusAssignmentDto>(busAssignment);
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

        public async Task<BusAssignmentDto> CreateAsync(CreateBusAssignmentDto createDto)
        {
            var busAssignment = _mapper.Map<BusAssignment>(createDto);
            busAssignment.IsActive = true;
            
            await _unitOfWork.BusAssignments.AddAsync(busAssignment);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BusAssignmentDto>(busAssignment);
        }

        public async Task<BusAssignmentDto> UpdateAsync(UpdateBusAssignmentDto updateDto)
        {
            var busAssignment = await _unitOfWork.BusAssignments.GetByIdAsync(updateDto.Id);
            if (busAssignment == null)
                return null;

            _mapper.Map(updateDto, busAssignment);
            await _unitOfWork.BusAssignments.UpdateAsync(busAssignment);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BusAssignmentDto>(busAssignment);
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