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
        
        // Additional properties needed for the view
        public int Capacity { get; set; }
        public string AssignmentNumber { get; set; } = string.Empty;
        public DateTime TourDate { get; set; }
        public string BusPlateNumber { get; set; } = string.Empty;
        public string BusModel { get; set; } = string.Empty;
    }
} 