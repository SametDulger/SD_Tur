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
        public async Task<ActionResult<InvoiceDetailDto>> Create(CreateInvoiceDetailDto createInvoiceDetailDto)
        {
            var createdInvoiceDetail = await _invoiceDetailService.CreateAsync(createInvoiceDetailDto);
            return CreatedAtAction(nameof(GetById), new { id = createdInvoiceDetail.Id }, createdInvoiceDetail);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceDetailDto>> Update(int id, UpdateInvoiceDetailDto updateInvoiceDetailDto)
        {
            if (id != updateInvoiceDetailDto.Id)
                return BadRequest();

            var updatedInvoiceDetail = await _invoiceDetailService.UpdateAsync(updateInvoiceDetailDto);
            if (updatedInvoiceDetail == null)
                return NotFound();

            return Ok(updatedInvoiceDetail);
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
