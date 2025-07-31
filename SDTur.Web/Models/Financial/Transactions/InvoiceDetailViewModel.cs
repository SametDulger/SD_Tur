using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fatura ID")]
        public int InvoiceId { get; set; }

        [Display(Name = "Ürün/Hizmet Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Birim Fiyat")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Toplam Fiyat")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "KDV Oranı (%)")]
        public decimal TaxRate { get; set; }

        [Display(Name = "KDV Tutarı")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Güncellenme Tarihi")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 