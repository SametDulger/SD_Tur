using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.Tour
{
    public class BusAssignment : BaseEntity
    {
        public int BusId { get; set; }
        public int TourScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Status { get; set; } = string.Empty; // Assigned, Completed, Cancelled
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Bus Bus { get; set; } = null!;
        public virtual TourSchedule TourSchedule { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
} 