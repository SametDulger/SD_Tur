using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

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
        public async Task<ActionResult<RegionDto>> CreateRegion(CreateRegionDto createRegionDto)
        {
            var region = await _regionService.CreateRegionAsync(createRegionDto);
            return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, UpdateRegionDto updateRegionDto)
        {
            if (id != updateRegionDto.Id)
                return BadRequest();

            var region = await _regionService.UpdateRegionAsync(updateRegionDto);
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