using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int Duration { get; set; }
        public DateTime TourDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
        public bool HasTickets { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string TourType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
        // Computed properties for compatibility with views
        public DateTime StartDate => TourDate;
        public DateTime EndDate => TourDate.AddDays(Duration);
        public int TotalSeats => Capacity;
        public int BookedSeats => Capacity - AvailableSeats;
    }
}