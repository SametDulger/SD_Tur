using System;
using SDTur.Core.Entities.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities.Master
{
    public class Nationality : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(3)]
        public string Code { get; set; } = string.Empty;
    }
} 