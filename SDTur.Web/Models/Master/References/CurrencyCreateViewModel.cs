using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class CurrencyCreateViewModel
    {
        [Required]
        public string CurrencyCode { get; set; } = string.Empty;
        
        [Required]
        public string CurrencyName { get; set; } = string.Empty;
        
        public string Symbol { get; set; } = string.Empty;
        
        public decimal ExchangeRate { get; set; }
        
        public bool IsDefault { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Kod")]
        public string Code { get; set; } = string.Empty;
        
        [Display(Name = "Para Birimi Adı")]
        public string Name { get; set; } = string.Empty;
    }
} 