using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class FinancialReport : BaseEntity
    {
        public string ReportType { get; set; } // Daily, Weekly, Monthly, Yearly
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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
        public virtual Employee Employee { get; set; }
    }
} 