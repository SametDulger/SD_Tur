namespace SDTur.Web.Models.Tour.Financial
{
    public class TourReportViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        
        // Additional properties for compatibility
        public string Status => IsApproved ? "Onaylandı" : "Beklemede";
        public string AuthorName => Author;
        public string ReportNumber { get; set; } = string.Empty;
    }
} 