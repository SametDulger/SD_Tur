using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Bus : BaseEntity
    {
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int Year { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string DriverPhone { get; set; } = string.Empty;
        public string DriverLicense { get; set; } = string.Empty;
        public DateTime LastMaintenance { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int TotalTours { get; set; }
        public int TotalPassengers { get; set; }
        public decimal TotalRevenue { get; set; }
        public bool HasActiveTours { get; set; }
        public bool IsOwned { get; set; } // Kendi aracımız mı?
        
        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
} 