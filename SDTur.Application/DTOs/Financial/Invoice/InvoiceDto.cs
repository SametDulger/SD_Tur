using System;
using System.Collections.Generic;
using SDTur.Application.DTOs.Financial.InvoiceDetail;

namespace SDTur.Application.DTOs.Financial.Invoice
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int PassCompanyId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string? PassCompanyName { get; set; }
        public List<InvoiceDetailDto>? InvoiceDetails { get; set; }
    }
} 