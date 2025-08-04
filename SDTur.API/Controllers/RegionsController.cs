using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.Region;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            var regions = await _regionService.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetActiveRegions()
        {
            var regions = await _regionService.GetActiveRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
            var region = await _regionService.GetRegionByIdAsync(id);
            if (region == null)
                return NotFound();

            return Ok(region);
        }

        [HttpPost]
        public async Task<ActionResult<RegionDto>> Create(CreateRegionDto createDto)
        {
            var region = await _regionService.CreateAsync(createDto);
            if (region == null)
                return BadRequest("Failed to create region");
            return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRegionDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var region = await _regionService.UpdateAsync(updateDto);
            if (region == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            await _regionService.DeleteRegionAsync(id);
            return NoContent();
        }
    }
} 
