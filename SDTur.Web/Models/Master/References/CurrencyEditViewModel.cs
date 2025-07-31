using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class CurrencyEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Para Birimi Adı")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Sembol")]
        public string Symbol { get; set; } = string.Empty;
        
        [Display(Name = "Döviz Kuru")]
        public decimal ExchangeRate { get; set; }
        
        [Display(Name = "Varsayılan")]
        public bool IsDefault { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 