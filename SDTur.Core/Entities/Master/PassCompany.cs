using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Entities.Financial;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class PassCompany : BaseEntity
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<PassAgreement> PassAgreements { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
} 