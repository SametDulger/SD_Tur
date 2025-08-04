using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities.Financial
{
    public class Invoice : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }

        public int? PassCompanyId { get; set; }
        public virtual PassCompany? PassCompany { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = string.Empty; // USD, EUR, TRY

        public string Status { get; set; } = string.Empty; // Draft, Sent, Paid, Cancelled

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
} 