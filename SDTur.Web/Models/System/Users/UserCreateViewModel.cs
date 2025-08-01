using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Users
{
    public class UserCreateViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 