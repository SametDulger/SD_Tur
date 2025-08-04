using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Auth
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad gereklidir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad gereklidir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Rol")]
        public string Role { get; set; } = string.Empty;

        [Display(Name = "Şube")]
        public string BranchName { get; set; } = string.Empty;

        [Display(Name = "Çalışan")]
        public string EmployeeName { get; set; } = string.Empty;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        [Display(Name = "Tam Ad")]
        public string FullName => $"{FirstName} {LastName}";
    }
} 