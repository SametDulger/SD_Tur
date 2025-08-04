using System;

namespace SDTur.Application.DTOs.System.SystemLog
{
    public class SystemLogDto
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string? LogLevel { get; set; }
        public string? Category { get; set; }
        public string? Action { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        
        // Navigation properties
        public string? UserName { get; set; }
        public string? EmployeeName { get; set; }
    }
} 