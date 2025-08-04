using System;

namespace SDTur.Application.DTOs.Financial.ExchangeRate
{
    public class UpdateExchangeRateDto
    {
        public int Id { get; set; }
        public string? FromCurrency { get; set; }
        public string? ToCurrency { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
} 