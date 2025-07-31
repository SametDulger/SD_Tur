using System;
using SDTur.Core.Entities.Core;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
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