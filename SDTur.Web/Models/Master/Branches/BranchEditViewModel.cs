using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Branches
{
    public class BranchEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Şube Kodu")]
        public string BranchCode { get; set; } = string.Empty;
        [Required]
        public string BranchName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Ad")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Yönetici")]
        public string Manager { get; set; } = string.Empty;
    }
} 