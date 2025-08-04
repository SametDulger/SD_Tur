using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.System
{
    public class SystemLog : BaseEntity
    {
        public DateTime LogDate { get; set; }
        public string LogLevel { get; set; } = string.Empty; // Info, Warning, Error, Debug
        public string Category { get; set; } = string.Empty; // User, System, Security, Business
        public string Action { get; set; } = string.Empty; // Create, Update, Delete, Login, etc.
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty; // JSON formatında detaylı bilgi
        public string IpAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        
        // Foreign keys
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        
        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Employee? Employee { get; set; }
    }
} 