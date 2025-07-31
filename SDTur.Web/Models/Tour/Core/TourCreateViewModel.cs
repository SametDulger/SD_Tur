using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime TourDate { get; set; }
        [Required]
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
    }
}