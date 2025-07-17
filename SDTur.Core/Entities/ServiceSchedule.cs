using System;
using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class ServiceSchedule : BaseEntity
    {
        public DateTime ServiceDate { get; set; }
        public TimeSpan ServiceTime { get; set; }
        public bool IsActive { get; set; }
        
        // Foreign keys
        public int TourId { get; set; }
        public int RegionId { get; set; }
        
        // Navigation properties
        public virtual Tour Tour { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
} 