using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = string.Empty;
        
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;
        
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;
        
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Display(Name = "Rol ID")]
        public int RoleId { get; set; } // Changed from string Role to int RoleId
        
        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; } = string.Empty; // For display purposes
        
        [Display(Name = "Çalışan ID")]
        public int? EmployeeId { get; set; }
        
        [Display(Name = "Şube ID")]
        public int? BranchId { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Son Giriş Tarihi")]
        public DateTime? LastLoginDate { get; set; }
        
        // Computed properties
        [Display(Name = "Tam Ad")]
        public string FullName => $"{FirstName} {LastName}".Trim();
        
        [Display(Name = "Şube Adı")]
        public string BranchName { get; set; } = string.Empty;
    }
} 