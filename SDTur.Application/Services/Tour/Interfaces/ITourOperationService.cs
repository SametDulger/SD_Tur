using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.TourOperation;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourOperationService
    {
        Task<IEnumerable<TourOperationDto>> GetAllAsync();
        Task<TourOperationDto?> GetByIdAsync(int id);
        Task<IEnumerable<TourOperationDto>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourOperationDto>> GetByOperationTypeAsync(string operationType);
        Task<IEnumerable<TourOperationDto>> GetByStatusAsync(string status);
        Task<TourOperationDto?> CreateAsync(CreateTourOperationDto createDto);
        Task<TourOperationDto?> UpdateAsync(UpdateTourOperationDto updateDto);
        Task DeleteAsync(int id);
    }
} 