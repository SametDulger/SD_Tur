using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.BusAssignment
{
    public class UpdateBusAssignmentDto
    {
        public int Id { get; set; }

        [Required]
        public int TourScheduleId { get; set; }

        [Required]
        public int BusId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime AssignmentDate { get; set; }

        [Required]
        public string? Status { get; set; }

        public string? Notes { get; set; }

        public bool IsActive { get; set; }
    }
} 