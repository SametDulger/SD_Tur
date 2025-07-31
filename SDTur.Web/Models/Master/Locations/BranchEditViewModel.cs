using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Locations
{
    public class BranchEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 