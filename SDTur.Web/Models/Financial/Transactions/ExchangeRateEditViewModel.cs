using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class ExchangeRateEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur")]
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Kaynak para birimi zorunludur")]
        [Display(Name = "Kaynak Para Birimi")]
        public string SourceCurrency { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hedef para birimi zorunludur")]
        [Display(Name = "Hedef Para Birimi")]
        public string TargetCurrency { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kaynak para birimi zorunludur")]
        [Display(Name = "Kaynak Para Birimi")]
        public string FromCurrency { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hedef para birimi zorunludur")]
        [Display(Name = "Hedef Para Birimi")]
        public string ToCurrency { get; set; } = string.Empty;

        [Required(ErrorMessage = "Döviz kuru zorunludur")]
        [Display(Name = "Döviz Kuru")]
        [Range(0, double.MaxValue, ErrorMessage = "Döviz kuru 0'dan büyük olmalıdır")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Kur tarihi zorunludur")]
        [Display(Name = "Kur Tarihi")]
        public DateTime RateDate { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}