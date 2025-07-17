using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
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

    public class UpdateExchangeRateDto
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
} 