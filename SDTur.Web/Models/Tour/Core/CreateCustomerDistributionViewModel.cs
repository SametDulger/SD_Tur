using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class CreateCustomerDistributionViewModel
    {
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public DateTime DistributionDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 