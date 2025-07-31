using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceDetailCreateViewModel
    {
        [Required(ErrorMessage = "Fatura ID zorunludur")]
        [Display(Name = "Fatura ID")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Ürün/Hizmet adı zorunludur")]
        [Display(Name = "Ürün/Hizmet Adı")]
        [StringLength(200, ErrorMessage = "Ürün/Hizmet adı en fazla 200 karakter olabilir")]
        public string ProductName { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur")]
        [Display(Name = "Miktar")]
        [Range(1, int.MaxValue, ErrorMessage = "Miktar 1'den büyük olmalıdır")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Birim fiyat zorunludur")]
        [Display(Name = "Birim Fiyat")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Birim fiyat 0'dan büyük olmalıdır")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "KDV oranı zorunludur")]
        [Display(Name = "KDV Oranı (%)")]
        [Range(0, 100, ErrorMessage = "KDV oranı 0-100 arasında olmalıdır")]
        public decimal TaxRate { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 