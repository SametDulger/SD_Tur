using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Tour
{
    public class ServiceSchedule : BaseEntity
    {
        public DateTime ServiceDate { get; set; }
        public TimeSpan ServiceTime { get; set; }
        
        // Foreign keys
        public int TourId { get; set; }
        public int RegionId { get; set; }
        
        // Navigation properties
        public virtual Tour Tour { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
} 