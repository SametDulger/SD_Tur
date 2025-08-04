using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Branch
{
    public class UpdateBranchDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? BranchCode { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? BranchName { get; set; }
        
        [Required]
        public string? Address { get; set; }
        
        [Required]
        public string? City { get; set; }
        
        [Required]
        public string? Country { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? ManagerName { get; set; }
        
        public string? Manager { get; set; }
        
        public string? Description { get; set; }
        
        public bool IsMainBranch { get; set; }
        
        public string? RegionName { get; set; }
        
        public bool IsActive { get; set; }
    }
}