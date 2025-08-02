using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class CommissionCalculationViewModel
    {
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        public string EmployeeName { get; set; } = string.Empty;
        
        public int TourId { get; set; }
        
        public string TourName { get; set; } = string.Empty;
        
        public decimal CommissionAmount { get; set; }
        
        public decimal CommissionRate { get; set; }
        
        public DateTime CalculationDate { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public bool IsPaid { get; set; }
        
        [Display(Name = "Hesaplama Tipi")]
        public string CalculationType { get; set; } = string.Empty;
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Bilet ID")]
        public int? TicketId { get; set; }
        
        [Display(Name = "Tur Programı ID")]
        public int? TourScheduleId { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Komisyon Tipi")]
        public string CommissionType { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
        
        // Additional properties needed for the view
        [Display(Name = "Onaylandı")]
        public bool IsApproved { get; set; }
        
        [Display(Name = "Hesaplama Numarası")]
        public string CalculationNumber { get; set; } = string.Empty;
        
        [Display(Name = "Tur Tarihi")]
        public DateTime TourDate { get; set; }
        
        [Display(Name = "Satış Tutarı")]
        public decimal SalesAmount { get; set; }
    }
} 