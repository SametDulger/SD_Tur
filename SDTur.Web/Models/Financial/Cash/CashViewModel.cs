namespace SDTur.Web.Models.Financial.Cash
{
    public class CashViewModel
    {
        public int Id { get; set; }
        public string CashType { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsAutomatic { get; set; }
        public bool IsActive { get; set; }
        public int? TicketId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PassCompanyId { get; set; }
    }
} 