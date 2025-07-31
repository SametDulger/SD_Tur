namespace SDTur.Web.Models.Tour.Financial
{
    public class TourIncomeViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int TourScheduleId { get; set; }
        public string IncomeType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public bool IsReceived { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 