using AutoMapper;
using SDTur.Application.DTOs.Master.Branch;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
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
            var branches = await _unitOfWork.Branches.GetAllAsync();
            return _mapper.Map<IEnumerable<BranchDto>>(branches.Where(b => b.IsActive));
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
            
            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BranchDto>(branch);
        }

        public async Task<BranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(updateBranchDto.Id);
            if (branch == null)
                return null;

            _mapper.Map(updateBranchDto, branch);
            await _unitOfWork.Branches.UpdateAsync(branch);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BranchDto>(branch);
        }

        public async Task DeleteBranchAsync(int id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null)
                return;

            await _unitOfWork.Branches.DeleteAsync(branch.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 