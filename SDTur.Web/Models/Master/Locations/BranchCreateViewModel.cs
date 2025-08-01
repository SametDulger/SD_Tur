using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Locations
{
    public class BranchCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? RegionId { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 