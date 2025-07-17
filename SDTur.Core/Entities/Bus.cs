using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class Bus : BaseEntity
    {
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public bool IsOwned { get; set; } // Kendi aracımız mı?
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
} 