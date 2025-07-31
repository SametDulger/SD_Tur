using System;

namespace SDTur.Application.DTOs.Tour.CustomerDistribution
{
    public class CustomerDistributionDto
    {
        public int Id { get; set; }
        public DateTime DistributionDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public int TourScheduleId { get; set; }
        public int BusId { get; set; }
        public int TicketId { get; set; }
        public int? EmployeeId { get; set; }
        public int CustomerCount { get; set; }
        public DateTime CreatedDate { get; set; }
        
        // Navigation properties
        public string TourName { get; set; }
        public DateTime TourDate { get; set; }
        public string BusPlateNumber { get; set; }
        public string CustomerName { get; set; }
        public string HotelName { get; set; }
        public string RegionName { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TourScheduleInfo { get; set; }
        public string BusInfo { get; set; }
        public string TicketInfo { get; set; }
    }
} 