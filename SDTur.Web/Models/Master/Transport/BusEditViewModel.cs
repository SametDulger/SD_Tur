using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Transport
{
    public class BusEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PlateNumber { get; set; } = string.Empty;
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Year { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string DriverPhone { get; set; } = string.Empty;
        public bool IsOwned { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastMaintenance { get; set; }
        
        [Display(Name = "Sürücü Ehliyeti")]
        public string DriverLicense { get; set; } = string.Empty;
        
        [Display(Name = "Son Bakım Tarihi")]
        public DateTime LastMaintenanceDate { get; set; }
        
        [Display(Name = "Sonraki Bakım Tarihi")]
        public DateTime NextMaintenanceDate { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
    }
} 