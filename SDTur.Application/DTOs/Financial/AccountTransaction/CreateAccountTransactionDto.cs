using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.AccountTransaction
{
    public class CreateAccountTransactionDto
    {
        [Required]
        public int AccountId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}