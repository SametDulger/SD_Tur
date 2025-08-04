using System;
using System.Collections.Generic;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Master
{
    public class PassAgreement : BaseEntity
    {
        public decimal OutgoingFullPrice { get; set; } // Giden pas full fiyatı
        public decimal OutgoingHalfPrice { get; set; } // Giden pas yarım fiyatı
        public decimal IncomingFullPrice { get; set; } // Gelen pas full fiyatı
        public decimal IncomingHalfPrice { get; set; } // Gelen pas yarım fiyatı
        public string Currency { get; set; } = string.Empty;
        
        // Foreign keys
        public int PassCompanyId { get; set; }
        public int TourId { get; set; }
        
        // Navigation properties
        public virtual PassCompany PassCompany { get; set; } = null!;
        public virtual SDTur.Core.Entities.Tour.Tour Tour { get; set; } = null!;
    }
} 