using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Master
{
    public class Branch : BaseEntity
    {
        public string BranchCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMainBranch { get; set; }
        public string RegionName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; } // Çalışan sayısı
        
        // Navigation properties
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
} 