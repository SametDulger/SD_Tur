using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Hotel
{
    public class CreateHotelDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int StarRating { get; set; }
        public string? ContactPerson { get; set; }
        public int Rating { get; set; }
        [Required]
        public int RegionId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 