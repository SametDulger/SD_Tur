using System;
using System.Collections.Generic;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Tour
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty; // USD, EUR, TRY
        public int Duration { get; set; } // Saat cinsinden
        public DateTime TourDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
        public bool HasTickets { get; set; }
        public string Destination { get; set; } = string.Empty;
        
        // Foreign key
        public int TourTypeId { get; set; }
        
        // Navigation properties
        public virtual TourType TourType { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<TourSchedule> TourSchedules { get; set; } = new List<TourSchedule>();
        public virtual ICollection<ServiceSchedule> ServiceSchedules { get; set; } = new List<ServiceSchedule>();
    }
} 