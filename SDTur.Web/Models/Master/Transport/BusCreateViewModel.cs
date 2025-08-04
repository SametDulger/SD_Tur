using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Transport
{
    public class BusCreateViewModel
    {
        [Required]
        public string PlateNumber { get; set; } = string.Empty;
        
        [Required]
        public string Brand { get; set; } = string.Empty;
        
        [Required]
        public string Model { get; set; } = string.Empty;
        
        [Required]
        public int Capacity { get; set; }
        
        [Required]
        [Display(Name = "Model Yılı")]
        public int Year { get; set; }
        
        [Display(Name = "Son Bakım Tarihi")]
        public DateTime? LastMaintenance { get; set; }
        
        [Display(Name = "Sürücü Adı")]
        public string DriverName { get; set; } = string.Empty;
        
        [Display(Name = "Sürücü Telefonu")]
        public string DriverPhone { get; set; } = string.Empty;
        
        [Display(Name = "Kendi Otobüsümüz")]
        public bool IsOwned { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
} 