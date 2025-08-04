using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceDetailEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura ID zorunludur")]
        [Display(Name = "Fatura ID")]
        public int InvoiceId { get; set; }

        [Display(Name = "Fatura Numarası")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ürün/Hizmet adı zorunludur")]
        [Display(Name = "Ürün/Hizmet Adı")]
        [StringLength(200, ErrorMessage = "Ürün/Hizmet adı en fazla 200 karakter olabilir")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Ürün Kodu")]
        [StringLength(50, ErrorMessage = "Ürün kodu en fazla 50 karakter olabilir")]
        public string ProductCode { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Miktar zorunludur")]
        [Display(Name = "Miktar")]
        [Range(1, int.MaxValue, ErrorMessage = "Miktar 1'den büyük olmalıdır")]
        public int Quantity { get; set; }

        [Display(Name = "Birim")]
        public string Unit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birim fiyat zorunludur")]
        [Display(Name = "Birim Fiyat")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Birim fiyat 0'dan büyük olmalıdır")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "KDV oranı zorunludur")]
        [Display(Name = "KDV Oranı (%)")]
        [Range(0, 100, ErrorMessage = "KDV oranı 0-100 arasında olmalıdır")]
        public decimal VatRate { get; set; }
        public decimal TaxRate { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 