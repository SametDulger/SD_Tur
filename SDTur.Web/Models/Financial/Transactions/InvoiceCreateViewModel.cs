using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceCreateViewModel
    {
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? TourId { get; set; }
        public bool IsActive { get; set; } = true;
        public int? PassCompanyId { get; set; }
    }
}