using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourExpense
{
    public class UpdateTourExpenseDto
    {
        [Required]
        public int Id { get; set; }
        
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
        
        public string? Currency { get; set; }
        
        public bool IsActive { get; set; }
    }
}