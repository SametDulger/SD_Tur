using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.Nationality;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalityService _nationalityService;

        public NationalitiesController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalityDto>>> GetAll()
        {
            var nationalities = await _nationalityService.GetAllAsync();
            return Ok(nationalities);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<NationalityDto>>> GetActive()
        {
            var nationalities = await _nationalityService.GetActiveAsync();
            return Ok(nationalities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NationalityDto>> GetById(int id)
        {
            var nationality = await _nationalityService.GetByIdAsync(id);
            if (nationality == null)
                return NotFound();

            return Ok(nationality);
        }

        [HttpPost]
        public async Task<ActionResult<NationalityDto>> Create(CreateNationalityDto createDto)
        {
            try
            {
                var nationality = await _nationalityService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = nationality.Id }, nationality);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NationalityDto>> Update(int id, UpdateNationalityDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var nationality = await _nationalityService.UpdateAsync(updateDto);
                return Ok(nationality);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _nationalityService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 