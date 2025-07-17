using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Destination { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateTourDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public string Destination { get; set; }
        
        [Required]
        public decimal BasePrice { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string Currency { get; set; }
        
        public bool IsActive { get; set; } = true;
    }

    public class UpdateTourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Destination { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
    }
} 