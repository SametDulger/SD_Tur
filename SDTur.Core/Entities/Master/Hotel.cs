using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; } // Bölge içindeki sıra
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual Region Region { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
} 