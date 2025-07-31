using System;

namespace SDTur.Application.DTOs.Tour.TourOperation
{
    public class UpdateTourOperationDto
    {
        public int Id { get; set; }
        public int TourScheduleId { get; set; }
        public string TourScheduleName { get; set; }
        public int BusId { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperationType { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}