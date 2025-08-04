using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Tour
{
    public class TourType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
    }
} 