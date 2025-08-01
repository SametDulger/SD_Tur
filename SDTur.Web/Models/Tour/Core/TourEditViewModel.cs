using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public DateTime TourDate { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        public bool IsActive { get; set; }
        
        [Display(Name = "Tur Türü")]
        public int? TourTypeId { get; set; }
        
        [Display(Name = "Kalkış Yeri")]
        public string DepartureLocation { get; set; } = string.Empty;
        
        [Display(Name = "Varış Yeri")]
        public string DestinationLocation { get; set; } = string.Empty;
        
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Para Birimi")]
        public int? CurrencyId { get; set; }
        
        [Display(Name = "Rehber")]
        public string GuideName { get; set; } = string.Empty;
        
        [Display(Name = "Rehber Telefonu")]
        public string GuidePhone { get; set; } = string.Empty;
        
        [Display(Name = "Ulaşım Türü")]
        public string TransportType { get; set; } = string.Empty;
    }
}