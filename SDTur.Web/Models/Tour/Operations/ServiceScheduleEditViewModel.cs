using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class ServiceScheduleEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public int RegionId { get; set; }
        
        [Required]
        public DateTime ServiceDate { get; set; }
        
        [Required]
        public string ServiceTime { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        // Additional properties for compatibility with views
        public string ServiceType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
} 