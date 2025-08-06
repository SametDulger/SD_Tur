using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.Tour
{
    public class CreateTourDto
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public string? Destination { get; set; }
        
        [Required]
        public decimal BasePrice { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int TourTypeId { get; set; }
        
        public string? Currency { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
} 