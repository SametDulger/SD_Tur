using System;

namespace SDTur.Application.DTOs.Master.Hotel
{
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