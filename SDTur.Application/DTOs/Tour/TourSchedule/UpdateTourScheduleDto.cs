using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourSchedule
{
    public class UpdateTourScheduleDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int TourId { get; set; }
        
        public string? TourName { get; set; }
        
        [Required]
        public DateTime DepartureDate { get; set; }
        
        [Required]
        public DateTime ReturnDate { get; set; }
        
        [Required]
        public DateTime TourDate { get; set; }
        
        [Required]
        public int MaxCapacity { get; set; }
        
        [Required]
        public int CurrentCapacity { get; set; }
        
        [Required]
        public int TotalPax { get; set; }
        
        [Required]
        public int FullPax { get; set; }
        
        [Required]
        public int HalfPax { get; set; }
        
        [Required]
        public int GuestPax { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string? Currency { get; set; }
        
        [Required]
        public string? Status { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public bool IsCancelled { get; set; }
        
        [Required]
        public decimal TotalIncome { get; set; }
        
        [Required]
        public decimal TotalExpense { get; set; }
        
        [Required]
        public decimal NetProfit { get; set; }
        
        public string? Notes { get; set; }
    }
}