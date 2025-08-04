using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Region : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int DistanceFromKemer { get; set; } // Kemer'e uzaklık (km)
        public int Order { get; set; } // Servis sırası
        public int HotelCount { get; set; } // Otel sayısı
        
        // Navigation properties
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public virtual ICollection<ServiceSchedule> ServiceSchedules { get; set; } = new List<ServiceSchedule>();
    }
} 