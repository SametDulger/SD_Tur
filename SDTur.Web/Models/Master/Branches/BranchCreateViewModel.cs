using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Branches
{
    public class BranchCreateViewModel
    {
        [Required]
        public string BranchName { get; set; } = string.Empty;
        
        [Display(Name = "Şube Kodu")]
        public string BranchCode { get; set; } = string.Empty;
        
        [Display(Name = "Bölge")]
        public int? RegionId { get; set; }
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        public string City { get; set; } = string.Empty;
        
        [Required]
        public string Country { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string ManagerName { get; set; } = string.Empty;
        
        [Display(Name = "Müdür Telefonu")]
        public string ManagerPhone { get; set; } = string.Empty;
        
        [Display(Name = "Çalışan Sayısı")]
        public int? EmployeeCount { get; set; }
        
        [Display(Name = "Açılış Tarihi")]
        public DateTime? OpeningDate { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
} 