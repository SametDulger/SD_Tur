using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities
{
    public class Nationality : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 