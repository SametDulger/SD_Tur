using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.ServiceSchedule
{
    public class UpdateServiceScheduleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tur seçimi zorunludur")]
        public int TourId { get; set; }

        [Required(ErrorMessage = "Bölge seçimi zorunludur")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Servis saati zorunludur")]
        public TimeSpan ServiceTime { get; set; }

        public bool IsActive { get; set; }
    }
} 