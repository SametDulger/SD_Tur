using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Invoices
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Fatura Numarası")]
        public string InvoiceNumber { get; set; } = string.Empty;
        
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; }
        
        [Display(Name = "Vade Tarihi")]
        public DateTime DueDate { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Tur")]
        public int? TourId { get; set; }
        
        [Display(Name = "Tur Adı")]
        public string TourName { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Pas Şirketi")]
        public int? PassCompanyId { get; set; }
        
        [Display(Name = "Pas Şirketi Adı")]
        public string PassCompanyName { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Ödendi")]
        public bool IsPaid { get; set; }
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        // Additional properties needed for the view
        [Display(Name = "Onaylandı")]
        public bool IsApproved { get; set; }
        
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
    }
} 