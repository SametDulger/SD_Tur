using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Branches
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Şube Kodu")]
        public string BranchCode { get; set; } = string.Empty;
        
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
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Çalışan Sayısı")]
        public int EmployeeCount { get; set; }
        
        // Additional properties for compatibility
        public bool IsMainBranch { get; set; }
        public string RegionName { get; set; } = string.Empty;
    }
}