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
        public virtual Invoice Invoice { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } // USD, EUR, TRY

        public int? TourScheduleId { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 