namespace SDTur.Web.Models.Financial.Reports
{
    public class FinancialReportViewModel
    {
        public int Id { get; set; }
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
    }
} 