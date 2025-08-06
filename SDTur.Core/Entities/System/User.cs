using System;
using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.System
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        
        public DateTime? LastLoginDate { get; set; }
        
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        
        public int? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
        
        // Role relationship
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
        
        // Navigation properties for refresh tokens
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
} 