using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class TicketCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public bool IsPaid { get; set; } = false;
        public string Status { get; set; } = string.Empty;
        
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
    }
} 