using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class CustomerDistributionEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string DistributionType { get; set; } = string.Empty;
        [Required]
        public DateTime DistributionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        
        // Additional properties for compatibility
        public int TourScheduleId { get; set; }
        public string CustomerType { get; set; } = string.Empty;
        
        // Missing properties that are referenced in the view
        [Required]
        public int BusId { get; set; }
        [Required]
        public int TicketId { get; set; }
        public int? EmployeeId { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 