using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.Tour
{
    public class UpdateTourDto
    {
        [Required]
        public int Id { get; set; }
        
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
        public int CurrencyId { get; set; }
        
        public string? Currency { get; set; }
        
        public bool IsActive { get; set; }
    }
} 