using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Users
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 