using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class BusAssignmentEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Display(Name = "Tur Programı")]
        public int? TourScheduleId { get; set; }
        
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public int BusId { get; set; }
        
        [Display(Name = "Sürücü")]
        public int? EmployeeId { get; set; }
        
        [Required]
        public int DriverId { get; set; }
        
        [Required]
        public DateTime AssignmentDate { get; set; }
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
    }
} 