using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.PassAgreement
{
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
} 