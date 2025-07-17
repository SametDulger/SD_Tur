using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string RegionName { get; set; }
        public RegionDto Region { get; set; }
    }

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

    public class UpdateHotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
} 