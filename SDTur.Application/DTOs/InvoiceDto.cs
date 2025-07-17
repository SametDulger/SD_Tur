using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int PassCompanyId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string PassCompanyName { get; set; }
        public List<InvoiceDetailDto> InvoiceDetails { get; set; }
    }

    public class CreateInvoiceDto
    {
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
    }

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

    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int? TourScheduleId { get; set; }
        public string TourScheduleInfo { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateInvoiceDetailDto
    {
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
    }

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