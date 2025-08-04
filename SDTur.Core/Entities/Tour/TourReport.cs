using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.Tour
{
    public class TourReport : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public string ReportType { get; set; } = string.Empty; // CustomerList, Financial, Operational
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
        public string ReportData { get; set; } = string.Empty; // JSON formatında detaylı veri
        public string Status { get; set; } = string.Empty; // Draft, Final, Archived
        
        // Foreign keys
        public int EmployeeId { get; set; }
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
} 