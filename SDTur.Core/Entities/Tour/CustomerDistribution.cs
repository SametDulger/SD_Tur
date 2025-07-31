using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.Tour
{
    public class CustomerDistribution : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public int BusId { get; set; }
        public int TicketId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DistributionDate { get; set; }
        public string Status { get; set; } // Assigned, Confirmed, Cancelled
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Employee Employee { get; set; }
    }
} 