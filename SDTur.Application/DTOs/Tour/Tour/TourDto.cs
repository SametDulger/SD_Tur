using System;

namespace SDTur.Application.DTOs.Tour.Tour
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Destination { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 