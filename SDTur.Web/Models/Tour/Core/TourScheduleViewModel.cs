namespace SDTur.Web.Models.Tour.Core
{
    public class TourScheduleViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public DateTime ScheduleDate { get; set; }
        public DateTime TourDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; } = string.Empty;
        
        // Additional properties for view compatibility
        public DateTime StartDate => ScheduleDate;
        public string Name => TourName;
    }
} 