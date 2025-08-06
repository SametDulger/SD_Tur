using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Transport
{
    public class BusCreateViewModel
    {
        [Required(ErrorMessage = "Plaka numarası zorunludur")]
        [StringLength(20, ErrorMessage = "Plaka numarası en fazla 20 karakter olabilir")]
        [RegularExpression(@"^[0-9]{2}\s*[A-Z]{1,3}\s*[0-9]{2,4}$", ErrorMessage = "Geçerli bir plaka formatı giriniz (Örn: 34 ABC 123)")]
        [Display(Name = "Plaka")]
        public string PlateNumber { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Marka zorunludur")]
        [StringLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir")]
        [Display(Name = "Marka")]
        public string Brand { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Model zorunludur")]
        [StringLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir")]
        [Display(Name = "Model")]
        public string Model { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Kapasite zorunludur")]
        [Range(1, 100, ErrorMessage = "Kapasite 1-100 arasında olmalıdır")]
        [Display(Name = "Kapasite")]
        public int Capacity { get; set; }
        
        [Required(ErrorMessage = "Model yılı zorunludur")]
        [Range(1900, 2030, ErrorMessage = "Geçerli bir model yılı giriniz")]
        [Display(Name = "Model Yılı")]
        public int Year { get; set; }
        
        [Display(Name = "Son Bakım Tarihi")]
        public DateTime? LastMaintenance { get; set; }
        
        [StringLength(100, ErrorMessage = "Sürücü adı en fazla 100 karakter olabilir")]
        [Display(Name = "Sürücü Adı")]
        public string DriverName { get; set; } = string.Empty;
        
        [StringLength(20, ErrorMessage = "Sürücü telefonu en fazla 20 karakter olabilir")]
        [RegularExpression(@"^[0-9+\-\s()]*$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Sürücü Telefonu")]
        public string DriverPhone { get; set; } = string.Empty;
        
        [Display(Name = "Kendi Otobüsümüz")]
        public bool IsOwned { get; set; }
        
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(1000, ErrorMessage = "Notlar en fazla 1000 karakter olabilir")]
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 