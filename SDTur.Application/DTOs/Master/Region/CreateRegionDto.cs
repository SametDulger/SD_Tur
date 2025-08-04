using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Region
{
    public class CreateRegionDto
    {
        [Required]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public int DistanceFromKemer { get; set; }
        
        [Required]
        public int Order { get; set; }
    }
} 