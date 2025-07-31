using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Master
{
    public class Currency : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [StringLength(5)]
        public string Symbol { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 