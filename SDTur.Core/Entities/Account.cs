using System;
using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class Account : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; } // PassCompany, BusCompany, Employee, Other
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Currency { get; set; } // USD, EUR, TRY
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
} 