using System;

namespace SDTur.Application.DTOs.Financial.AccountTransaction
{
    public class UpdateAccountTransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public int CurrencyId { get; set; }
        public string? TransactionType { get; set; }
        public string? Description { get; set; }
        public string? Reference { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsActive { get; set; }
    }
}