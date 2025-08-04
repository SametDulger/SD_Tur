using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string City { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public int Order { get; set; } // Bölge içindeki sıra
        
        // Navigation properties
        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
} 