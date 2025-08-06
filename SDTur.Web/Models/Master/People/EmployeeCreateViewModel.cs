using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.People
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Telefon zorunludur")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        [RegularExpression(@"^[0-9+\-\s()]*$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "İşe başlama tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "İşe Başlama Tarihi")]
        public DateTime HireDate { get; set; }
        
        [Required(ErrorMessage = "Pozisyon zorunludur")]
        [StringLength(100, ErrorMessage = "Pozisyon en fazla 100 karakter olabilir")]
        [Display(Name = "Pozisyon")]
        public string Position { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Şube seçimi zorunludur")]
        [Display(Name = "Şube")]
        public int BranchId { get; set; }
        
        [Required(ErrorMessage = "Para birimi seçimi zorunludur")]
        [Display(Name = "Para Birimi")]
        public int CurrencyId { get; set; }
        
        [Required(ErrorMessage = "Maaş zorunludur")]
        [Range(0, 1000000, ErrorMessage = "Maaş 0-1.000.000 arasında olmalıdır")]
        [Display(Name = "Maaş")]
        public decimal Salary { get; set; }
        
        [Range(0, 100, ErrorMessage = "Komisyon oranı 0-100 arasında olmalıdır")]
        [Display(Name = "Komisyon Oranı (%)")]
        public decimal CommissionRate { get; set; }
        
        [StringLength(500, ErrorMessage = "Adres en fazla 500 karakter olabilir")]
        [Display(Name = "Adres")]
        public string Address { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 