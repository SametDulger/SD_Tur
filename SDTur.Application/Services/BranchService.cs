using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BranchDto>> GetAllBranchesAsync()
        {
            var branches = await _unitOfWork.Branches.GetAllAsync();
            return _mapper.Map<IEnumerable<BranchDto>>(branches);
        }

        public async Task<IEnumerable<BranchDto>> GetActiveBranchesAsync()
        {
            var branches = await _unitOfWork.Branches.GetActiveBranchesAsync();
            return _mapper.Map<IEnumerable<BranchDto>>(branches);
        }

        public async Task<BranchDto> GetBranchByIdAsync(int id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            return _mapper.Map<BranchDto>(branch);
        }

        public async Task<BranchDto> CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            var branch = _mapper.Map<Branch>(createBranchDto);
            branch.IsActive = true;
            
            var createdBranch = await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BranchDto>(createdBranch);
        }

        public async Task<BranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto)
        {
            var existingBranch = await _unitOfWork.Branches.GetByIdAsync(updateBranchDto.Id);
            if (existingBranch == null)
                return null;

            _mapper.Map(updateBranchDto, existingBranch);
            
            var updatedBranch = await _unitOfWork.Branches.UpdateAsync(existingBranch);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BranchDto>(updatedBranch);
        }

        public async Task DeleteBranchAsync(int id)
        {
            await _unitOfWork.Branches.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 