using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Branch
{
    public class CreateBranchDto
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Address { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}