using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Branch;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDto>> GetAllBranchesAsync();
        Task<IEnumerable<BranchDto>> GetActiveBranchesAsync();
        Task<BranchDto?> GetBranchByIdAsync(int id);
        Task<BranchDto?> CreateAsync(CreateBranchDto createBranchDto);
        Task<BranchDto?> UpdateAsync(UpdateBranchDto updateBranchDto);
        Task DeleteBranchAsync(int id);
    }
} 