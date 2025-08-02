using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Bilet Numarası")]
        public string TicketNumber { get; set; } = string.Empty;
        
        [Display(Name = "Tur Tarihi")]
        public DateTime TourDate { get; set; }
    }
} 