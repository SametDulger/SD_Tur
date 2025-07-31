using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountCreateViewModel
    {
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        [Required]
        public string AccountName { get; set; } = string.Empty;
        [Required]
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        [Required]
        public string Currency { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 