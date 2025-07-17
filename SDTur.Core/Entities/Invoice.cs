using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities
{
    public class Invoice : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int? PassCompanyId { get; set; }
        public virtual PassCompany PassCompany { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } // USD, EUR, TRY

        public string Status { get; set; } // Draft, Sent, Paid, Cancelled

        [StringLength(500)]
        public string Notes { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
} 