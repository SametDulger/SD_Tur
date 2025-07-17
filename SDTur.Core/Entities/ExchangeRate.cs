using System;

namespace SDTur.Core.Entities
{
    public class ExchangeRate : BaseEntity
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 