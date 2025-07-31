using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Logs
{
    public class SystemLogCreateViewModel
    {
        [Required]
        public string LogLevel { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Required]
        public string Action { get; set; } = string.Empty;
        
        [Display(Name = "Kaynak")]
        public string Source { get; set; } = string.Empty;
        
        [Display(Name = "Log Tarihi")]
        public DateTime? LogDate { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        [Display(Name = "Hata Detayı")]
        public string Exception { get; set; } = string.Empty;
        
        public string Details { get; set; } = string.Empty;
        
        public string IpAddress { get; set; } = string.Empty;
        
        public string UserAgent { get; set; } = string.Empty;
        
        public string UserId { get; set; } = string.Empty;
        
        public int? EmployeeId { get; set; }
    }
} 