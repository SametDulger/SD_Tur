using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Cash
{
    public class CashCreateViewModel
    {
        [Required]
        public string CashType { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public bool IsApproved { get; set; } = false;
        [Required]
        public string Currency { get; set; } = string.Empty;
    }
} 