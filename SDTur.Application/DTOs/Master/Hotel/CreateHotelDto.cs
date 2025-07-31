using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Hotel
{
    public class CreateHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public int RegionId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 