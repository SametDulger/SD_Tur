using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class CreateServiceScheduleViewModel
    {
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        [Required]
        public string ServiceTime { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 