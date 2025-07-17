namespace SDTur.Core.Entities
{
    public class PassAgreement : BaseEntity
    {
        public decimal OutgoingFullPrice { get; set; } // Giden pas full fiyatı
        public decimal OutgoingHalfPrice { get; set; } // Giden pas yarım fiyatı
        public decimal IncomingFullPrice { get; set; } // Gelen pas full fiyatı
        public decimal IncomingHalfPrice { get; set; } // Gelen pas yarım fiyatı
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        
        // Foreign keys
        public int PassCompanyId { get; set; }
        public int TourId { get; set; }
        
        // Navigation properties
        public virtual PassCompany PassCompany { get; set; }
        public virtual Tour Tour { get; set; }
    }
} 