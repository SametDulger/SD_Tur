using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs;
using SDTur.Application.Services;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassAgreementsController : ControllerBase
    {
        private readonly IPassAgreementService _passAgreementService;

        public PassAgreementsController(IPassAgreementService passAgreementService)
        {
            _passAgreementService = passAgreementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassAgreementDto>>> GetAll()
        {
            var passAgreements = await _passAgreementService.GetAllAsync();
            return Ok(passAgreements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassAgreementDto>> GetById(int id)
        {
            var passAgreement = await _passAgreementService.GetByIdAsync(id);
            if (passAgreement == null)
                return NotFound();

            return Ok(passAgreement);
        }

        [HttpGet("passcompany/{passCompanyId}")]
        public async Task<ActionResult<IEnumerable<PassAgreementDto>>> GetByPassCompany(int passCompanyId)
        {
            var passAgreements = await _passAgreementService.GetByPassCompanyAsync(passCompanyId);
            return Ok(passAgreements);
        }

        [HttpGet("tour/{tourId}")]
        public async Task<ActionResult<IEnumerable<PassAgreementDto>>> GetByTour(int tourId)
        {
            var passAgreements = await _passAgreementService.GetByTourAsync(tourId);
            return Ok(passAgreements);
        }

        [HttpPost]
        public async Task<ActionResult<PassAgreementDto>> Create(CreatePassAgreementDto createDto)
        {
            try
            {
                var passAgreement = await _passAgreementService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = passAgreement.Id }, passAgreement);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PassAgreementDto>> Update(int id, UpdatePassAgreementDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var passAgreement = await _passAgreementService.UpdateAsync(updateDto);
                return Ok(passAgreement);
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
                await _passAgreementService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 