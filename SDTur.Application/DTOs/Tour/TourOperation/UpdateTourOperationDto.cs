using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.TourOperation
{
    public class UpdateTourOperationDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int TourScheduleId { get; set; }
        
        public string? TourScheduleName { get; set; }
        
        [Required]
        public int BusId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        [Required]
        public DateTime OperationDate { get; set; }
        
        public string? OperationType { get; set; }
        
        public string? Status { get; set; }
        
        public string? Notes { get; set; }
        
        public bool IsActive { get; set; }
    }
}