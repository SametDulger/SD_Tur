using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.InvoiceDetail;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailsController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetailDto>>> GetAll()
        {
            var invoiceDetails = await _invoiceDetailService.GetAllAsync();
            return Ok(invoiceDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailDto>> GetById(int id)
        {
            var invoiceDetail = await _invoiceDetailService.GetByIdAsync(id);
            if (invoiceDetail == null)
                return NotFound();

            return Ok(invoiceDetail);
        }

        [HttpGet("invoice/{invoiceId}")]
        public async Task<ActionResult<IEnumerable<InvoiceDetailDto>>> GetByInvoiceId(int invoiceId)
        {
            var invoiceDetails = await _invoiceDetailService.GetByInvoiceIdAsync(invoiceId);
            return Ok(invoiceDetails);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDetailDto>> Create(CreateInvoiceDetailDto createDto)
        {
            var createdInvoiceDetail = await _invoiceDetailService.CreateAsync(createDto);
            if (createdInvoiceDetail == null)
                return BadRequest("Failed to create invoice detail");
            return CreatedAtAction(nameof(GetById), new { id = createdInvoiceDetail.Id }, createdInvoiceDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateInvoiceDetailDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var updatedInvoiceDetail = await _invoiceDetailService.UpdateAsync(updateDto);
            if (updatedInvoiceDetail == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _invoiceDetailService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
} 
