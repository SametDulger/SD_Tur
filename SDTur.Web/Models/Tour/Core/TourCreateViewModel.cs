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
        public int Duration { get; set; }
        
        [Required]
        public string Destination { get; set; } = string.Empty;
        
        [Required]
        public decimal BasePrice { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string Currency { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        // Additional properties for view compatibility
        [Display(Name = "Tur Tarihi")]
        public DateTime TourDate { get; set; }
        
        [Required]
        [Display(Name = "Kapasite")]
        public int Capacity { get; set; }
        
        [Display(Name = "Kalkış Yeri")]
        public string DepartureLocation { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Varış Yeri")]
        public string DestinationLocation { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Rehber")]
        public string GuideName { get; set; } = string.Empty;
        
        [Display(Name = "Rehber Telefonu")]
        public string GuidePhone { get; set; } = string.Empty;
        
        [Display(Name = "Ulaşım Türü")]
        public string TransportType { get; set; } = string.Empty;
        
        [Display(Name = "Güzergah")]
        public string Itinerary { get; set; } = string.Empty;
        
        [Display(Name = "Tur Tipi")]
        public string TourType { get; set; } = string.Empty;
    }
}