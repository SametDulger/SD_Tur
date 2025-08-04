using System;
using System.ComponentModel.DataAnnotations;
using SDTur.Core.Entities.Core;

namespace SDTur.Core.Entities.Master
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
} 