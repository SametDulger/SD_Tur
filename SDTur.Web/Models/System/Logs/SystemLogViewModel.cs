namespace SDTur.Web.Models.System.Logs
{
    public class SystemLogViewModel
    {
        public int Id { get; set; }
        public string LogLevel { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public DateTime LogDate { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Additional properties for compatibility with views
        public string Source => Category;
        public string Exception => Details;
    }
} 