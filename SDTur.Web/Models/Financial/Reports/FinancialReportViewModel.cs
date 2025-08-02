using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Reports
{
    public class FinancialReportViewModel
    {
        public int Id { get; set; }
        
        public string ReportType { get; set; } = string.Empty;
        
        public DateTime ReportDate { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public decimal TotalIncome { get; set; }
        
        public decimal TotalExpense { get; set; }
        
        public decimal NetProfit { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public bool IsApproved { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Rapor Verisi")]
        public string ReportData { get; set; } = string.Empty;
        
        [Display(Name = "Çalışan ID")]
        public int EmployeeId { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Çalışan Adı")]
        public string EmployeeName { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
        
        // Additional properties needed for the view
        [Display(Name = "Rapor Numarası")]
        public string ReportNumber { get; set; } = string.Empty;
        
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }
    }
} 