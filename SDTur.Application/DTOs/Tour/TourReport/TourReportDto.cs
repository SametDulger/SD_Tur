using System;

namespace SDTur.Application.DTOs.Tour.TourReport
{
    public class TourReportDto
    {
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalFullCount { get; set; }
        public int TotalHalfCount { get; set; }
        public int TotalGuestCount { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Currency { get; set; }
        public string ReportData { get; set; }
        public string Status { get; set; }
        public int? TourId { get; set; }
        public int? EmployeeId { get; set; }
        
        // Navigation properties
        public string TourName { get; set; }
        public string EmployeeName { get; set; }
    }
} 