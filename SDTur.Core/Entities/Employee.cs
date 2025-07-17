using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; } // Sales, Operations, Accounting, DataEntry, IT
        public decimal Salary { get; set; }
        public int CurrencyId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal CommissionRate { get; set; } // Komisyon oranı (%)
        public bool IsActive { get; set; }
        public int BranchId { get; set; }
        
        // Navigation properties
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Ticket> SoldTickets { get; set; }
        public virtual ICollection<CommissionCalculation> CommissionCalculations { get; set; }
    }
} 