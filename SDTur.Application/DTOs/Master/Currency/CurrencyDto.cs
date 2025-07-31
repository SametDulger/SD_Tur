using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Currency
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }
} 