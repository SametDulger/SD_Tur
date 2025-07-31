using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;

namespace SDTur.Core.Entities.System
{
    public class SystemLog : BaseEntity
    {
        public DateTime LogDate { get; set; }
        public string LogLevel { get; set; } // Info, Warning, Error, Debug
        public string Category { get; set; } // User, System, Security, Business
        public string Action { get; set; } // Create, Update, Delete, Login, etc.
        public string Message { get; set; }
        public string Details { get; set; } // JSON formatında detaylı bilgi
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Foreign keys
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual Employee Employee { get; set; }
    }
} 