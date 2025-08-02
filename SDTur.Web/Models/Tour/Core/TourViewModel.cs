using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime TourDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsActive { get; set; }
        
        [Display(Name = "Toplam Bilet")]
        public int TotalTickets { get; set; }
        
        [Display(Name = "Toplam Gelir")]
        public decimal TotalRevenue { get; set; }
        
        [Display(Name = "Bilet Var Mı")]
        public bool HasTickets { get; set; }
        
        // Additional properties for compatibility
        public DateTime StartDate => TourDate;
        public int TotalSeats => Capacity;
        public int BookedSeats => Capacity - AvailableSeats;
        public string Destination { get; set; } = string.Empty;
        public string TourType { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}