using System;

namespace SDTur.Application.DTOs.Tour.TourSchedule
{
    public class TourScheduleDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string? TourName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime TourDate { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public int TotalPax { get; set; }
        public int FullPax { get; set; }
        public int HalfPax { get; set; }
        public int GuestPax { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 