using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Financial
{
    public class TourReportCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public string ReportType { get; set; } = string.Empty;
        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        public bool IsApproved { get; set; } = false;
    }
} 