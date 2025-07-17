using System;

namespace SDTur.Core.Entities
{
    public class TourReport : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public string ReportType { get; set; } // CustomerList, Financial, Operational
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
        public string Currency { get; set; }
        public string ReportData { get; set; } // JSON formatında detaylı veri
        public string Status { get; set; } // Draft, Final, Archived
        public bool IsActive { get; set; } = true;
        
        // Foreign keys
        public int EmployeeId { get; set; }
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Employee Employee { get; set; }
    }
} 