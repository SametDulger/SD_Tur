using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class UpdateTourScheduleViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int MaxCapacity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 