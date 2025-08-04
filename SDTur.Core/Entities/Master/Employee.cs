using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // Sales, Operations, Accounting, DataEntry, IT
        public decimal Salary { get; set; }
        public int CurrencyId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal CommissionRate { get; set; } // Komisyon oranı (%)
        public int BranchId { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmployeeNumber { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string FullName { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Ticket> SoldTickets { get; set; } = new List<Ticket>();
        public virtual ICollection<CommissionCalculation> CommissionCalculations { get; set; } = new List<CommissionCalculation>();
    }
} 