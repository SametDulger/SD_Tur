using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Locations
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int DistanceFromKemer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Otel Sayısı")]
        public int HotelCount { get; set; }
    }
} 