using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Branch
{
    public class UpdateBranchDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Address { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        public bool IsActive { get; set; }
    }
}