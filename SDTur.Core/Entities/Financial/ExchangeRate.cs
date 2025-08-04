using System;
using SDTur.Core.Entities.Core;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class ExchangeRate : BaseEntity
    {
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public DateTime RateDate { get; set; }
        public DateTime Date { get; set; }
    }
} 