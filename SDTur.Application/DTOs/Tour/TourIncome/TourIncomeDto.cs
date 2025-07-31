using System;

namespace SDTur.Application.DTOs.Tour.TourIncome
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
} 