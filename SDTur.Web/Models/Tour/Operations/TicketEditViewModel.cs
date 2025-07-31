using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class TicketEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; } = string.Empty;
    }
} 