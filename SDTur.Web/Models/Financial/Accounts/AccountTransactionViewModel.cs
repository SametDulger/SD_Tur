using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountTransactionViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        
        [Display(Name = "Hesap Numarası")]
        public string AccountNumber { get; set; } = string.Empty;
        
        [Display(Name = "İşlem Numarası")]
        public string TransactionNumber { get; set; } = string.Empty;
    }
} 