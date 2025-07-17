using System;

namespace SDTur.Application.DTOs
{
    public class FinancialReportDto
    {
        public int Id { get; set; }
        public string ReportTitle { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCashIncome { get; set; }
        public decimal TotalCashExpense { get; set; }
        public decimal NetCashFlow { get; set; }
        public decimal TotalAccountReceivable { get; set; }
        public decimal TotalAccountPayable { get; set; }
        public decimal NetAccountBalance { get; set; }
        public decimal TotalCommissionPaid { get; set; }
        public string Currency { get; set; }
        public string ReportData { get; set; }
        public string Status { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        public string EmployeeName { get; set; }
    }
} 