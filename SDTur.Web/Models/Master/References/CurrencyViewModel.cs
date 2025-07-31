using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class CurrencyViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Symbol { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Döviz Kuru")]
        public decimal ExchangeRate { get; set; }
        
        [Display(Name = "Son Güncelleme")]
        public DateTime LastUpdated { get; set; }
    }
} 