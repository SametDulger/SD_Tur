using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Tour
{
    public class TourOperation : BaseEntity
    {
        public int TourScheduleId { get; set; }
        public int BusId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperationType { get; set; } // Start, End, Cancel, Modify
        public string Status { get; set; } // Pending, Completed, Failed
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    }
} 