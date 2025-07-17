using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public string Role { get; set; } // Admin, Manager, Sales, DataEntry, Accounting, Operations

        public bool IsActive { get; set; } = true;
    }
} 