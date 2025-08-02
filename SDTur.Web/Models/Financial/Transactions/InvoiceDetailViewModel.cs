using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fatura ID")]
        public int InvoiceId { get; set; }

        [Display(Name = "Ürün/Hizmet Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

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
        
        [Display(Name = "Fatura Numarası")]
        public string InvoiceNumber { get; set; } = string.Empty;
        
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; } = string.Empty;
        
        [Display(Name = "Birim")]
        public string Unit { get; set; } = string.Empty;
        
        [Display(Name = "KDV Oranı")]
        public decimal VatRate { get; set; }
        
        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
        
        // Additional properties needed for the view
        [Display(Name = "Onaylandı")]
        public bool IsApproved { get; set; }
        
        [Display(Name = "Ürün/Hizmet")]
        public string ProductOrService { get; set; } = string.Empty;
    }
} 