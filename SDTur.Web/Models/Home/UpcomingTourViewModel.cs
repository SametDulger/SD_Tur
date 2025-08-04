using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Home
{
    public class UpcomingTourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime TourDate { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
    }
} 