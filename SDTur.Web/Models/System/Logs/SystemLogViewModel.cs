namespace SDTur.Web.Models.System.Logs
{
    public class SystemLogViewModel
    {
        public int Id { get; set; }
        public string LogLevel { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime LogDate { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
    }
} 