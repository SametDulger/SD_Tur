using System;

namespace SDTur.Application.DTOs.Master.PassAgreement
{
    public class PassAgreementDto
    {
        public int Id { get; set; }
        public int PassCompanyId { get; set; }
        public string? PassCompanyName { get; set; }
        public int TourId { get; set; }
        public string? TourName { get; set; }
        public decimal OutgoingFullPrice { get; set; }
        public decimal OutgoingHalfPrice { get; set; }
        public decimal IncomingFullPrice { get; set; }
        public decimal IncomingHalfPrice { get; set; }
        public string? Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 