using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class UpdateNationalityViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 