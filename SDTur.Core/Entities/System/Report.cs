using System;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.System
{
    public class Report : BaseEntity
    {
        public string ReportName { get; set; } = string.Empty;
        public string ReportType { get; set; } = string.Empty; // TourList, CustomerList, Financial, Pass
        public DateTime ReportDate { get; set; }
        public string Parameters { get; set; } = string.Empty; // JSON formatında parametreler
        public string GeneratedBy { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty; // PDF, Excel, CSV
    }
} 