using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class TourScheduleDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
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
        public string Currency { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateTourScheduleDto
    {
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public DateTime DepartureDate { get; set; }
        
        [Required]
        public DateTime ReturnDate { get; set; }
        
        [Required]
        public int MaxCapacity { get; set; }
        
        [Required]
        public int CurrentCapacity { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string Currency { get; set; }
        
        [Required]
        public string Status { get; set; }
        
        public string Notes { get; set; }
    }

    public class UpdateTourScheduleDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
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
        public string Currency { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; }
    }

    public class TourScheduleDetailDto
    {
        public int Id { get; set; }
        public DateTime TourDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public List<TourExpenseDto> Expenses { get; set; }
        public List<TourIncomeDto> Incomes { get; set; }
        public List<BusDto> AssignedBuses { get; set; }
    }
} 