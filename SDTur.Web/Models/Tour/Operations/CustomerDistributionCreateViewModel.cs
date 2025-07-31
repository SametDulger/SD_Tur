using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class CreateCustomerDistributionViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string DistributionType { get; set; } = string.Empty;
        [Required]
        public DateTime DistributionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
} 