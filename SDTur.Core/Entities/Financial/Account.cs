using System;
using SDTur.Core.Entities.Core;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class Account : BaseEntity
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty; // PassCompany, BusCompany, Employee, Other
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public string Currency { get; set; } = string.Empty; // USD, EUR, TRY
        
        // Navigation properties
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; } = new List<AccountTransaction>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
} 