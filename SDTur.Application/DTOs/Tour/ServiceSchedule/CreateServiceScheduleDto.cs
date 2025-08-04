using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.ServiceSchedule
{
    public class CreateServiceScheduleDto
    {
        [Required(ErrorMessage = "Tur seçimi zorunludur")]
        public int TourId { get; set; }

        [Required(ErrorMessage = "Bölge seçimi zorunludur")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Servis tarihi zorunludur")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Servis saati zorunludur")]
        public string ServiceTime { get; set; } = string.Empty;
    }
} 