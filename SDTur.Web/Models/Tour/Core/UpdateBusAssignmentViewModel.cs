using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class UpdateBusAssignmentViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public DateTime AssignmentDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 