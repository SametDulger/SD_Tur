using System;

namespace SDTur.Application.DTOs
{
    public class BusAssignmentDto
    {
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public int TourScheduleId { get; set; }
        public int BusId { get; set; }
        public int? EmployeeId { get; set; }
        
        // Navigation properties
        public string TourName { get; set; }
        public DateTime TourDate { get; set; }
        public string BusPlateNumber { get; set; }
        public string BusModel { get; set; }
        public int BusCapacity { get; set; }
        public string EmployeeName { get; set; }
    }
} 