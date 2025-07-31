using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Users
{
    public class UserEditViewModel
    {
        [Required]
        public int Id { get; set; }
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
        public string Role { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public bool IsActive { get; set; }
    }
} 