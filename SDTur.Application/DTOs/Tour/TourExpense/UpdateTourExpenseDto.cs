using System;

namespace SDTur.Application.DTOs.Tour.TourExpense
{
    public class UpdateTourExpenseDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
    }
}