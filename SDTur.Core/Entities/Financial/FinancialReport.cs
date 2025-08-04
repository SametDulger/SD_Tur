using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class FinancialReport : BaseEntity
    {
        public string ReportType { get; set; } = string.Empty; // Daily, Weekly, Monthly, Yearly
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string ReportData { get; set; } = string.Empty; // JSON formatında detaylı veri
        public string Status { get; set; } = string.Empty; // Draft, Final, Archived
        
        // Foreign keys
        public int EmployeeId { get; set; }
        
        // Navigation properties
        public virtual Employee Employee { get; set; } = null!;
    }
} 