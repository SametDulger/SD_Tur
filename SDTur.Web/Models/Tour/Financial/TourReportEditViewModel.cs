using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Financial
{
    public class TourReportEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int TourScheduleId { get; set; }
        
        [Required]
        public string ReportType { get; set; } = string.Empty;
        
        [Required]
        public DateTime ReportDate { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public int TotalCustomers { get; set; }
        
        [Required]
        public int FullPriceCustomers { get; set; }
        
        [Required]
        public int HalfPriceCustomers { get; set; }
        
        [Required]
        public int GuestCustomers { get; set; }
        
        [Required]
        public decimal TotalIncome { get; set; }
        
        [Required]
        public decimal TotalExpense { get; set; }
        
        [Required]
        public decimal NetProfit { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        public string ReportData { get; set; } = string.Empty;
        
        [Required]
        public string Status { get; set; } = string.Empty;
        
        [Required]
        public int EmployeeId { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Additional properties for compatibility with views
        public int TourId { get; set; }
        public bool IsApproved { get; set; }
        public string Content { get; set; } = string.Empty;
    }
} 