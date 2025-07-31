using System;

namespace SDTur.Application.DTOs.System.Report
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReportName { get; set; }
        public string Description { get; set; }
        public string ReportType { get; set; }
        public DateTime ReportDate { get; set; }
        public string GeneratedBy { get; set; }
        public string FilePath { get; set; }
        public string Parameters { get; set; }
        public string FileType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 