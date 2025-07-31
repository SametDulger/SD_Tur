using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Locations
{
    public class RegionEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public int DistanceFromKemer { get; set; }
        [Required]
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
} 