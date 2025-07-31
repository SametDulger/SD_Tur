using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class CurrencyCreateViewModel
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        public decimal ExchangeRate { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 