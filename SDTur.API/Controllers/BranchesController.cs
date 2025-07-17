using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetActiveBranches()
        {
            var branches = await _branchService.GetActiveBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDto>> GetBranch(int id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound();

            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult<BranchDto>> CreateBranch(CreateBranchDto createBranchDto)
        {
            var branch = await _branchService.CreateBranchAsync(createBranchDto);
            return CreatedAtAction(nameof(GetBranch), new { id = branch.Id }, branch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, UpdateBranchDto updateBranchDto)
        {
            if (id != updateBranchDto.Id)
                return BadRequest();

            var branch = await _branchService.UpdateBranchAsync(updateBranchDto);
            if (branch == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            await _branchService.DeleteBranchAsync(id);
            return NoContent();
        }
    }
} 