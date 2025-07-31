using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class ExchangeRateEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FromCurrency { get; set; } = string.Empty;
        [Required]
        public string ToCurrency { get; set; } = string.Empty;
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}