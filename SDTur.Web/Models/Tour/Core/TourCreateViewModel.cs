using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public DateTime TourDate { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        [Required]
        public string Destination { get; set; } = string.Empty;
        
        [Required]
        public int TourTypeId { get; set; }
    }
}