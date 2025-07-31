using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourOperation
{
    public class CreateTourOperationDto
    {
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public DateTime OperationDate { get; set; }
        public string OperationType { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}