using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDto>> GetAllBranchesAsync();
        Task<IEnumerable<BranchDto>> GetActiveBranchesAsync();
        Task<BranchDto> GetBranchByIdAsync(int id);
        Task<BranchDto> CreateBranchAsync(CreateBranchDto createBranchDto);
        Task<BranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto);
        Task DeleteBranchAsync(int id);
    }
} 