using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Branches
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        
        public string BranchName { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string City { get; set; } = string.Empty;
        
        public string Country { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string ManagerName { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Ad")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Yönetici")]
        public string Manager { get; set; } = string.Empty;
    }
}