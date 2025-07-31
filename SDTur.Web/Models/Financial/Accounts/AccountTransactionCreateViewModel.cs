using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountTransactionCreateViewModel
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string TransactionType { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime TransactionDate { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public int? RelatedTransactionId { get; set; }
        public int? TransferAccountId { get; set; }
        public int? CurrencyId { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 