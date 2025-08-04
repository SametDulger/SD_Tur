using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Auth
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ad gereklidir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Rol")]
        public string Role { get; set; }

        [Display(Name = "Şube")]
        public string BranchName { get; set; }

        [Display(Name = "Çalışan")]
        public string EmployeeName { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        [Display(Name = "Tam Ad")]
        public string FullName => $"{FirstName} {LastName}";
    }
} 