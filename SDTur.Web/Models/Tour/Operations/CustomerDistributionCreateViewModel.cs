using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class CustomerDistributionCreateViewModel
    {
        [Required]
        public int TourScheduleId { get; set; }
        
        [Required]
        public int BusId { get; set; }
        
        [Required]
        public int TicketId { get; set; }
        
        public int? EmployeeId { get; set; }
        
        [Required]
        public DateTime DistributionDate { get; set; }
        
        [Required]
        public string Status { get; set; } = string.Empty;
        
        public string Notes { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        // Additional properties for view compatibility
        public string CustomerType { get; set; } = string.Empty;
        public string DistributionType { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
} 