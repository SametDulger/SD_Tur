using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Region
{
    public class UpdateRegionDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public string? Country { get; set; }
        
        [Required]
        public int DistanceFromKemer { get; set; }
        
        [Required]
        public int Order { get; set; }
        
        public bool IsActive { get; set; }
    }
} 