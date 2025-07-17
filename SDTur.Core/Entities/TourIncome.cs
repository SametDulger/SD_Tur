using System;

namespace SDTur.Core.Entities
{
    public class TourIncome : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Category { get; set; } // Ticket, Commission, Other
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; }
    }
} 