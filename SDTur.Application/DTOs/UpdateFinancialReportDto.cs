using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class UpdateFinancialReportDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        public string ReportType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalIncome { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalExpense { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal NetProfit { get; set; }

        [Required]
        public string Currency { get; set; }

        public string ReportData { get; set; }

        public string Status { get; set; }

        public int? EmployeeId { get; set; }

        public bool IsActive { get; set; }
    }
} 