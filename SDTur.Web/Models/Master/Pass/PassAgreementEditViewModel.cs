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
        public string AgreementNumber { get; set; } = string.Empty;
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public decimal CommissionRate { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Gidiş Tam Fiyat")]
        public decimal OutgoingFullPrice { get; set; }
        
        [Display(Name = "Gidiş Yarım Fiyat")]
        public decimal OutgoingHalfPrice { get; set; }
        
        [Display(Name = "Dönüş Tam Fiyat")]
        public decimal IncomingFullPrice { get; set; }
        
        [Display(Name = "Dönüş Yarım Fiyat")]
        public decimal IncomingHalfPrice { get; set; }
        
        [Display(Name = "Anlaşma Şartları")]
        public string Terms { get; set; } = string.Empty;
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
        public int? TourId { get; set; }
    }
} 