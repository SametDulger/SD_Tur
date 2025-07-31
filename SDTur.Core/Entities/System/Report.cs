using System;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.System
{
    public class Report : BaseEntity
    {
        public string ReportName { get; set; }
        public string ReportType { get; set; } // TourList, CustomerList, Financial, Pass
        public DateTime ReportDate { get; set; }
        public string Parameters { get; set; } // JSON formatında parametreler
        public string GeneratedBy { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; } // PDF, Excel, CSV
        public bool IsActive { get; set; }
    }
} 