using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Entities.Financial;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class PassCompany : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<PassAgreement> PassAgreements { get; set; } = new List<PassAgreement>();
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; } = new List<AccountTransaction>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
} 