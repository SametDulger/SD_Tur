using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities.Financial
{
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty; // USD, EUR, TRY

        public int? TourScheduleId { get; set; }
        public virtual TourSchedule? TourSchedule { get; set; }
    }
} 