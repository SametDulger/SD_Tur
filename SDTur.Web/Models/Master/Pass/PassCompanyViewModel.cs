using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Pass
{
    public class PassCompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Anlaşma Sayısı")]
        public int AgreementCount { get; set; }
        
        [Display(Name = "Aktif Anlaşma Var Mı")]
        public bool HasActiveAgreements { get; set; }
        
        [Display(Name = "Toplam Anlaşma")]
        public int TotalAgreements { get; set; }
        
        [Display(Name = "Aktif Anlaşmalar")]
        public int ActiveAgreements { get; set; }
        
        [Display(Name = "Toplam Gelir")]
        public decimal TotalRevenue { get; set; }
        
        [Display(Name = "Anlaşma Var Mı")]
        public bool HasAgreements { get; set; }
    }
} 