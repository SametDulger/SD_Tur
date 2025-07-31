using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Pass
{
    public class PassAgreementEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PassCompanyId { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public string AgreementNumber { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal CommissionRate { get; set; }
        public string Terms { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Required]
        public decimal OutgoingFullPrice { get; set; }
        [Required]
        public decimal OutgoingHalfPrice { get; set; }
        [Required]
        public decimal IncomingFullPrice { get; set; }
        [Required]
        public decimal IncomingHalfPrice { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
    }
} 