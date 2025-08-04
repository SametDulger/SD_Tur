using System;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Tour
{
    public class TourIncome : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Category { get; set; } = string.Empty; // Ticket, Commission, Other
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; } = null!;
    }
} 