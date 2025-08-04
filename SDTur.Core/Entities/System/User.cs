using System;
using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.System
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime? LastLoginDate { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
        public string Role { get; set; } = string.Empty; // Admin, Manager, Sales, DataEntry, Accounting, Operations
    }
} 