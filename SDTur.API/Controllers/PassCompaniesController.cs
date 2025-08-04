using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.PassCompany;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassCompaniesController : ControllerBase
    {
        private readonly IPassCompanyService _passCompanyService;

        public PassCompaniesController(IPassCompanyService passCompanyService)
        {
            _passCompanyService = passCompanyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassCompanyDto>>> GetAll()
        {
            var passCompanies = await _passCompanyService.GetAllAsync();
            return Ok(passCompanies);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<PassCompanyDto>>> GetActive()
        {
            var passCompanies = await _passCompanyService.GetActiveAsync();
            return Ok(passCompanies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassCompanyDto>> GetById(int id)
        {
            var passCompany = await _passCompanyService.GetByIdAsync(id);
            if (passCompany == null)
                return NotFound();

            return Ok(passCompany);
        }

        [HttpPost]
        public async Task<ActionResult<PassCompanyDto>> Create(CreatePassCompanyDto createDto)
        {
            var passCompany = await _passCompanyService.CreateAsync(createDto);
            if (passCompany == null)
                return BadRequest("Failed to create pass company");
            return CreatedAtAction(nameof(GetById), new { id = passCompany.Id }, passCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePassCompanyDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var passCompany = await _passCompanyService.UpdateAsync(updateDto);
            if (passCompany == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _passCompanyService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 
