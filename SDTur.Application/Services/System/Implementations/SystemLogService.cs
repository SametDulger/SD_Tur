using AutoMapper;
using SDTur.Application.DTOs.System.SystemLog;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.Application.Services.System.Implementations
{
    public class SystemLogService : ISystemLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SystemLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SystemLogDto>> GetAllAsync()
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetAllAsync();
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<SystemLogDto> GetByIdAsync(int id)
        {
            var systemLog = await _unitOfWork.SystemLogs.GetByIdAsync(id);
            return _mapper.Map<SystemLogDto>(systemLog);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByLogLevelAsync(string logLevel)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByLogLevelAsync(logLevel);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByCategoryAsync(string category)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByCategoryAsync(category);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByUserAsync(int userId)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByUserAsync(userId);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByEmployeeAsync(int employeeId)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByEmployeeAsync(employeeId);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<IEnumerable<SystemLogDto>> GetByActionAsync(string action)
        {
            var systemLogs = await _unitOfWork.SystemLogs.GetByActionAsync(action);
            return _mapper.Map<IEnumerable<SystemLogDto>>(systemLogs);
        }

        public async Task<SystemLogDto> CreateAsync(CreateSystemLogDto createDto)
        {
            var systemLog = _mapper.Map<SystemLog>(createDto);
            systemLog.IsActive = true;
            
            await _unitOfWork.SystemLogs.AddAsync(systemLog);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<SystemLogDto>(systemLog);
        }

        public async Task<SystemLogDto> UpdateAsync(UpdateSystemLogDto updateDto)
        {
            var existingSystemLog = await _unitOfWork.SystemLogs.GetByIdAsync(updateDto.Id);
            if (existingSystemLog == null)
                throw new ArgumentException("System log not found");
            
            _mapper.Map(updateDto, existingSystemLog);
            
            await _unitOfWork.SystemLogs.UpdateAsync(existingSystemLog);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<SystemLogDto>(existingSystemLog);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.SystemLogs.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 