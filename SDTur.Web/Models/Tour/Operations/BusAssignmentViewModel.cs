namespace SDTur.Web.Models.Tour.Operations
{
    public class BusAssignmentViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int BusId { get; set; }
        public string BusPlate { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public DateTime AssignmentDate { get; set; }
        public bool IsActive { get; set; }
    }
} 