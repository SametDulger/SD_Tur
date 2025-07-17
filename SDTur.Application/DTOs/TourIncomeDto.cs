using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class TourIncomeDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string TourScheduleInfo { get; set; }
        public string IncomeType { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateTourIncomeDto
    {
        [Required]
        public int TourScheduleId { get; set; }
        
        [Required]
        public string IncomeType { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime IncomeDate { get; set; }
        
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateTourIncomeDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string IncomeType { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
    }
} 