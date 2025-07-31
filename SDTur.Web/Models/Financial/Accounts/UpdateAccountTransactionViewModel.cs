using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class UpdateAccountTransactionViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        [Required]
        public string TransactionType { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        [Required]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 