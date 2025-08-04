using System;

namespace SDTur.Application.DTOs.Financial.CommissionCalculation
{
    public class CommissionCalculationDto
    {
        public int Id { get; set; }
        public DateTime CalculationDate { get; set; }
        public decimal TicketAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CommissionAmount { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int TicketId { get; set; }
        public int EmployeeId { get; set; }
        public int? TourScheduleId { get; set; }
        public string? CommissionType { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        public string? TicketNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? TourName { get; set; }
        public string? EmployeeName { get; set; }
        public string? BranchName { get; set; }
        public string? TicketInfo { get; set; }
        public string? TourScheduleInfo { get; set; }
    }
} 