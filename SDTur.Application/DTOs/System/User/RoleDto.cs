using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.System.User
{
    public class RoleDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Rol adı zorunludur")]
        [StringLength(50, ErrorMessage = "Rol adı en fazla 50 karakter olabilir")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Güncellenme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
    }
} 