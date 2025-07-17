using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
    }

    public class CreateUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, ErrorMessage = "Şifre en fazla 100 karakter olabilir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Rol zorunludur")]
        public string Role { get; set; }

        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
    }

    public class UpdateUserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string Username { get; set; }

        [StringLength(100, ErrorMessage = "Şifre en fazla 100 karakter olabilir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Rol zorunludur")]
        public string Role { get; set; }

        public bool IsActive { get; set; }
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
    }
} 