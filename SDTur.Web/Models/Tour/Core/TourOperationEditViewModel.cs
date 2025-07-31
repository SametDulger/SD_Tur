using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourOperationEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public string OperationType { get; set; } = string.Empty;
        [Required]
        public DateTime OperationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Cost { get; set; }
        public bool IsCompleted { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 