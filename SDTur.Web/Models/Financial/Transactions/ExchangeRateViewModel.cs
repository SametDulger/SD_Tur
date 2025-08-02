using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class ExchangeRateViewModel
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
        
        // Additional property needed for the view
        [Display(Name = "Para Birimi Kodu")]
        public string CurrencyCode { get; set; } = string.Empty;
    }
} 