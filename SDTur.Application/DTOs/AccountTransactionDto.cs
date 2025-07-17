using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class AccountTransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int? TourScheduleId { get; set; }
        public string TourScheduleInfo { get; set; }
        public int? TicketId { get; set; }
        public string TicketInfo { get; set; }
        public int? PassCompanyId { get; set; }
        public string PassCompanyInfo { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public int CurrencyId { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

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

    public class UpdateAccountTransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int CurrencyId { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsActive { get; set; }
    }
} 