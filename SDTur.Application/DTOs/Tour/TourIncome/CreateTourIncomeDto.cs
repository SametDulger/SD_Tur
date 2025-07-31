using System;

namespace SDTur.Application.DTOs.Tour.TourIncome
{
    public class CreateTourIncomeDto
    {
        public int TourScheduleId { get; set; }
        public string IncomeType { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Category { get; set; }
    }
} 