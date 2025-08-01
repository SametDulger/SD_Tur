using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourOperationCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string OperationType { get; set; } = string.Empty;
        [Required]
        public DateTime OperationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Cost { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? TourScheduleId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
} 