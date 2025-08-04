using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourExpense
{
    public class CreateTourExpenseDto
    {
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public string? ExpenseType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime ExpenseDate { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
    }
}