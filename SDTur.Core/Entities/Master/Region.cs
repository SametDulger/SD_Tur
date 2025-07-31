using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceFromKemer { get; set; } // Kemer'e uzaklık (km)
        public int Order { get; set; } // Servis sırası
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<ServiceSchedule> ServiceSchedules { get; set; }
    }
} 