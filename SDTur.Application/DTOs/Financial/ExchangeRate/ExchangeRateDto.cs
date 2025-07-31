using System;

namespace SDTur.Application.DTOs.Financial.ExchangeRate
{
    public class ExchangeRateDto
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrency { get; set; }
        public string ToCurrencyCode { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 