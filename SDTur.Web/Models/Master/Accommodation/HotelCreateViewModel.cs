using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Accommodation
{
    public class HotelCreateViewModel
    {
        [Required]
        [Display(Name = "Otel Adı")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        public string City { get; set; } = string.Empty;
        
        [Required]
        public string Country { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Display(Name = "İletişim Kişisi")]
        public string ContactPerson { get; set; } = string.Empty;
        
        public string Website { get; set; } = string.Empty;
        
        [Required]
        public int StarRating { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        [Required]
        // Additional property for compatibility
        public int RegionId { get; set; }
    }
} 