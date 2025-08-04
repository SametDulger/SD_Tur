using System;

namespace SDTur.Application.DTOs.Tour.TourOperation
{
    public class TourOperationDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string? TourScheduleName { get; set; }
        public int BusId { get; set; }
        public string? BusPlateNumber { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string? Currency { get; set; }
        public DateTime OperationDate { get; set; }
        public string? OperationType { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 