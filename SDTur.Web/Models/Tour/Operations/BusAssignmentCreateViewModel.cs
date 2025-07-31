using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class CreateBusAssignmentViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public DateTime AssignmentDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 