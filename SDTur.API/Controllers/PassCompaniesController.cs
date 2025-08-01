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
            try
            {
                var passCompany = await _passCompanyService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = passCompany.Id }, passCompany);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PassCompanyDto>> Update(int id, UpdatePassCompanyDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var passCompany = await _passCompanyService.UpdateAsync(updateDto);
                return Ok(passCompany);
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
