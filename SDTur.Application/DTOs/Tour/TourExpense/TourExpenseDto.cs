using System;

namespace SDTur.Application.DTOs.Tour.TourExpense
{
    public class TourExpenseDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string? TourScheduleInfo { get; set; }
        public string? ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Currency { get; set; }
        public string? Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 