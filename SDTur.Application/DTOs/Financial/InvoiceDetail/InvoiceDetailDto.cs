using System;

namespace SDTur.Application.DTOs.Financial.InvoiceDetail
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public int? TourScheduleId { get; set; }
        public string? TourScheduleInfo { get; set; }
        public bool IsActive { get; set; }
    }
} 