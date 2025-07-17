using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class ServiceScheduleDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public TimeSpan ServiceTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateServiceScheduleDto
    {
        [Required(ErrorMessage = "Tur seçimi zorunludur")]
        public int TourId { get; set; }

        [Required(ErrorMessage = "Bölge seçimi zorunludur")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Servis saati zorunludur")]
        public TimeSpan ServiceTime { get; set; }
    }

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