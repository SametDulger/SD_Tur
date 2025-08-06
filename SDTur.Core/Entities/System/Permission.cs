using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.System
{
    public class Permission : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Resource { get; set; } = string.Empty; // e.g., "Tour", "User", "Report"
        
        [Required]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty; // e.g., "Read", "Write", "Delete"
        
        public new bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
} 