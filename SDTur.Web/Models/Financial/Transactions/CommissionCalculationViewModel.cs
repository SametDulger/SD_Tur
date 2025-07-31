namespace SDTur.Web.Models.Financial.Transactions
{
    public class CommissionCalculationViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public decimal CommissionAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public DateTime CalculationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
} 