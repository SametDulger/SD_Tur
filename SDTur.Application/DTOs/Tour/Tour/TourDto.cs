using System;

namespace SDTur.Application.DTOs.Tour.Tour
{
    public class TourDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public int Duration { get; set; }
        public DateTime TourDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
        public bool HasTickets { get; set; }
        public string? Destination { get; set; }
        public string? TourType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 