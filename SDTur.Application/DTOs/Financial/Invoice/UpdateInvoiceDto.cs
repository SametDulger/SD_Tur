using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.Invoice
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura numarası zorunludur")]
        [StringLength(20, ErrorMessage = "Fatura numarası en fazla 20 karakter olabilir")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Fatura tarihi zorunludur")]
        public DateTime InvoiceDate { get; set; }

        public int? PassCompanyId { get; set; }

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Toplam tutar 0'dan büyük olmalıdır")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Para birimi zorunludur")]
        [StringLength(3, ErrorMessage = "Para birimi en fazla 3 karakter olabilir")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; }

        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string Notes { get; set; }

        public bool IsActive { get; set; }
    }
} 