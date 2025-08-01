using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Reports
{
    public class FinancialReportCreateViewModel
    {
        [Required]
        public string ReportName { get; set; } = string.Empty;
        
        [Required]
        public string ReportType { get; set; } = string.Empty;
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public int? BranchId { get; set; }
        
        public string Currency { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Rapor Tarihi")]
        public DateTime ReportDate { get; set; }
        
        [Display(Name = "Toplam Gelir")]
        public decimal TotalIncome { get; set; }
        
        [Display(Name = "Toplam Gider")]
        public decimal TotalExpense { get; set; }
        
        [Display(Name = "Net Kar")]
        public decimal NetProfit { get; set; }
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Rapor Verisi")]
        public string ReportData { get; set; } = string.Empty;
        
        [Display(Name = "Çalışan")]
        public int? EmployeeId { get; set; }
    }
}