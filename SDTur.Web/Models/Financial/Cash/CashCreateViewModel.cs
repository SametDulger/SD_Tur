using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Cash
{
    public class CashCreateViewModel
    {
        [Required]
        public int BranchId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        [Required]
        public string TransactionType { get; set; } = string.Empty;
        
        [Display(Name = "Nakit Tipi")]
        public string CashType { get; set; } = string.Empty;
        
        [Display(Name = "Onaylandı")]
        public bool IsApproved { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime TransactionDate { get; set; }
        
        public int? EmployeeId { get; set; }
        
        public string ReceiptNumber { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
} 