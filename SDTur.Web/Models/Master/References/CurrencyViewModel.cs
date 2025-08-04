using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.References
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Code { get; set; } = string.Empty;
        
        public string Symbol { get; set; } = string.Empty;
    }
} 