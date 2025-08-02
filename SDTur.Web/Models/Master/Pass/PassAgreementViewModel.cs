using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Pass
{
    public class PassAgreementViewModel
    {
        public int Id { get; set; }
        public int PassCompanyId { get; set; }
        public string PassCompanyName { get; set; } = string.Empty;
        public int TourId { get; set; }
        public string AgreementNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CommissionRate { get; set; }
        public string Terms { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public decimal OutgoingFullPrice { get; set; }
        public decimal OutgoingHalfPrice { get; set; }
        public decimal IncomingFullPrice { get; set; }
        public decimal IncomingHalfPrice { get; set; }
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Tur Adı")]
        public string TourName { get; set; } = string.Empty;
    }
} 