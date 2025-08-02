using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Transport
{
    public class BusViewModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
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
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Toplam Tur")]
        public int TotalTours { get; set; }
        
        [Display(Name = "Toplam Yolcu")]
        public int TotalPassengers { get; set; }
        
        [Display(Name = "Toplam Gelir")]
        public decimal TotalRevenue { get; set; }
        
        [Display(Name = "Aktif Tur Var Mı")]
        public bool HasActiveTours { get; set; }
        
        // Status properties for the view
        public string Status 
        {
            get
            {
                if (!IsActive) return "Inactive";
                if (DateTime.Now >= NextMaintenanceDate) return "Maintenance";
                return "Active";
            }
        }
        
        public string StatusText => IsActive ? "Aktif" : "Pasif";
    }
} 