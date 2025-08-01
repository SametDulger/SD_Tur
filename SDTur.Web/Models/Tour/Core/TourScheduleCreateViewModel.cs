using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourScheduleCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public TimeSpan DepartureTime { get; set; }
        [Required]
        public TimeSpan ArrivalTime { get; set; }
        [Required]
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        
        public DateTime TourDate { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
} 