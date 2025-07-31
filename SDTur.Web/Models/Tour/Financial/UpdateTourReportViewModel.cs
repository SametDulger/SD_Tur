using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Financial
{
    public class UpdateTourReportViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public string ReportType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 