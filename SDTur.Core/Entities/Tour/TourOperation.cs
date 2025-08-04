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
        public string OperationType { get; set; } = string.Empty; // Start, End, Cancel, Modify
        public string Status { get; set; } = string.Empty; // Pending, Completed, Failed
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual TourSchedule TourSchedule { get; set; } = null!;
        public virtual Bus Bus { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    }
} 