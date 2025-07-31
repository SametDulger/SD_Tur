using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.ExchangeRate
{
    public class CreateExchangeRateDto
    {
        [Required]
        public string FromCurrency { get; set; }
        [Required]
        public string ToCurrency { get; set; }
        [Required]
        public int FromCurrencyId { get; set; }
        [Required]
        public int ToCurrencyId { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public DateTime RateDate { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 