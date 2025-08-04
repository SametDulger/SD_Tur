using System;
using SDTur.Application.DTOs.Master.Region;

namespace SDTur.Application.DTOs.Master.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int StarRating { get; set; }
        public string? ContactPerson { get; set; }
        public int Rating { get; set; }
        public string? City { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string? RegionName { get; set; }
        public RegionDto? Region { get; set; }
    }
} 