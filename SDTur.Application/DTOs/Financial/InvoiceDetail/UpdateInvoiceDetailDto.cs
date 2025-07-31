using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.InvoiceDetail
{
    public class UpdateInvoiceDetailDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tutar zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Para birimi zorunludur")]
        [StringLength(3, ErrorMessage = "Para birimi en fazla 3 karakter olabilir")]
        public string Currency { get; set; }

        public int? TourScheduleId { get; set; }
        public bool IsActive { get; set; }
    }
} 