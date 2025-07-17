using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class PassAgreementDto
    {
        public int Id { get; set; }
        public int PassCompanyId { get; set; }
        public string PassCompanyName { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string AgreementNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AgreementDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal OutgoingFullPrice { get; set; }
        public decimal OutgoingHalfPrice { get; set; }
        public decimal IncomingFullPrice { get; set; }
        public decimal IncomingHalfPrice { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreatePassAgreementDto
    {
        [Required]
        public int PassCompanyId { get; set; }
        
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public string AgreementNumber { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public DateTime AgreementDate { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public decimal OutgoingFullPrice { get; set; }
        
        [Required]
        public decimal OutgoingHalfPrice { get; set; }
        
        [Required]
        public decimal IncomingFullPrice { get; set; }
        
        [Required]
        public decimal IncomingHalfPrice { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        [Required]
        public string Status { get; set; }
        
        public string Notes { get; set; }
        
        public bool IsActive { get; set; }
    }

    public class UpdatePassAgreementDto
    {
        public int Id { get; set; }
        public int PassCompanyId { get; set; }
        public int TourId { get; set; }
        public string AgreementNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AgreementDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal OutgoingFullPrice { get; set; }
        public decimal OutgoingHalfPrice { get; set; }
        public decimal IncomingFullPrice { get; set; }
        public decimal IncomingHalfPrice { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
} 