namespace SDTur.Web.Models.Tour.Operations
{
    public class ServiceScheduleViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public DateTime ServiceDate { get; set; }
        public TimeSpan ServiceTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
} 