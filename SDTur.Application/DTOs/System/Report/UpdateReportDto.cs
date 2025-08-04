using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.System.Report
{
    public class UpdateReportDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        [Required]
        public string? ReportName { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public string? ReportType { get; set; }
        
        [Required]
        public DateTime ReportDate { get; set; }
        
        public string? GeneratedBy { get; set; }
        
        public string? FilePath { get; set; }
        
        public string? Parameters { get; set; }
        
        public string? FileType { get; set; }
        
        public bool IsActive { get; set; }
    }
} 