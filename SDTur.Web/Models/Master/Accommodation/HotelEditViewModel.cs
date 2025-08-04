using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Accommodation
{
    public class HotelEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
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
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Range(1, 5)]
        public int StarRating { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public int Order { get; set; }
    }
} 