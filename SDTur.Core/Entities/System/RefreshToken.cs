using System;
using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.System
{
    public class RefreshToken : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Token { get; set; } = string.Empty;
        [Required]
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime? RevokedAt { get; set; }
        [StringLength(100)]
        public string? RevokedBy { get; set; }
        [StringLength(500)]
        public string? ReplacedByToken { get; set; }
        [StringLength(200)]
        public string? ReasonRevoked { get; set; }
        
        // Foreign key
        public int UserId { get; set; }
        
        // Navigation property
        public virtual User User { get; set; } = null!;
    }
} 