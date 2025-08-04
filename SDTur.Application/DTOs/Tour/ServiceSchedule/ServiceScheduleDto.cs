using System;

namespace SDTur.Application.DTOs.Tour.ServiceSchedule
{
    public class ServiceScheduleDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string? TourName { get; set; }
        public int RegionId { get; set; }
        public string? RegionName { get; set; }
        public TimeSpan ServiceTime { get; set; }
        public bool IsActive { get; set; }
    }
} 