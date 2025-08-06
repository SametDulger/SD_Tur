using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.System.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, ErrorMessage = "Şifre en fazla 100 karakter olabilir")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string? Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Rol zorunludur")]
        public int RoleId { get; set; }

        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
    }
}