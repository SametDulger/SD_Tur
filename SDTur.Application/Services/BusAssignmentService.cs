using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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
            var existingBusAssignment = await _unitOfWork.BusAssignments.GetByIdAsync(updateDto.Id);
            if (existingBusAssignment == null)
                throw new ArgumentException("Bus assignment not found");
            
            _mapper.Map(updateDto, existingBusAssignment);
            
            await _unitOfWork.BusAssignments.UpdateAsync(existingBusAssignment);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BusAssignmentDto>(existingBusAssignment);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.BusAssignments.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 