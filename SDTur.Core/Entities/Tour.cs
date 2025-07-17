using System;
using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } // USD, EUR, TRY
        public int Duration { get; set; } // Saat cinsinden
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TourSchedule> TourSchedules { get; set; }
        public virtual ICollection<ServiceSchedule> ServiceSchedules { get; set; }
    }
} 