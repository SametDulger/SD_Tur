using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Financial.Invoice;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<InvoiceDto>> GetWithDetails(int id)
        {
            var invoice = await _invoiceService.GetWithDetailsAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpGet("passcompany/{passCompanyId}")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByPassCompany(int passCompanyId)
        {
            var invoices = await _invoiceService.GetByPassCompanyAsync(passCompanyId);
            return Ok(invoices);
        }

        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var invoices = await _invoiceService.GetByDateRangeAsync(startDate, endDate);
            return Ok(invoices);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByStatus(string status)
        {
            var invoices = await _invoiceService.GetByStatusAsync(status);
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> Create(CreateInvoiceDto createDto)
        {
            try
            {
                var invoice = await _invoiceService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceDto>> Update(int id, UpdateInvoiceDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var invoice = await _invoiceService.UpdateAsync(updateDto);
                return Ok(invoice);
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
                await _invoiceService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 
