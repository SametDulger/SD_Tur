namespace SDTur.Web.Models.Tour.Core
{
    public class TourOperationViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int TourScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int BusId { get; set; }
        public string OperationType { get; set; } = string.Empty;
        public DateTime OperationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public bool IsCompleted { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 