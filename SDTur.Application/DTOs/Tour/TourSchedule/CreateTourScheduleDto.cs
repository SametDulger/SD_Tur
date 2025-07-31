using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourSchedule
{
    public class CreateTourScheduleDto
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int MaxCapacity { get; set; }
        [Required]
        public int CurrentCapacity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        [Required]
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}