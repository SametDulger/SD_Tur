namespace SDTur.Web.Models.Master.References
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
    }
} 