using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Logs
{
    public class SystemLogEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string LogLevel { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Required]
        public string Action { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public string Details { get; set; } = string.Empty;
        
        public string IpAddress { get; set; } = string.Empty;
        
        public string UserAgent { get; set; } = string.Empty;
        
        public DateTime LogDate { get; set; }
        
        public int? UserId { get; set; }
        
        public int? EmployeeId { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Additional properties for compatibility with views
        public string Source { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
    }
} 