using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Users
{
    public class UserEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Rol seçimi zorunludur")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; } // Changed from string Role to int RoleId
        
        [Display(Name = "Çalışan ID")]
        public int? EmployeeId { get; set; }
        
        [Display(Name = "Şube ID")]
        public int? BranchId { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 