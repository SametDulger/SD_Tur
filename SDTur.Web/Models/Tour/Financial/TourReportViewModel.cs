namespace SDTur.Web.Models.Tour.Financial
{
    public class TourReportViewModel
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalCustomers { get; set; }
        public int FullPriceCustomers { get; set; }
        public int HalfPriceCustomers { get; set; }
        public int GuestCustomers { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string ReportData { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string TourName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Additional properties for compatibility with views
        public int TourId => TourScheduleId;
        public string Author => EmployeeName;
        public string AuthorName => EmployeeName;
        public string Content => ReportData;
        public bool IsApproved => Status == "Final";
        public string ReportNumber => $"RPT-{Id:D4}";
    }
} 