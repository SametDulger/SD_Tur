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
        public string Status { get; set; } // Assigned, Completed, Cancelled
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual Bus Bus { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Employee Employee { get; set; }
    }
} 