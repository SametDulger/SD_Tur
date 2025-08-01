using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Invoices
{
    public class InvoiceEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
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
        
        [Display(Name = "Pas Şirketi")]
        public int? PassCompanyId { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        
        public int? TourId { get; set; }
        
        public bool IsActive { get; set; }
    }
} 