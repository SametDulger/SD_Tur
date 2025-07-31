using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.CommissionCalculation
{
    public class CreateCommissionCalculationDto
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public int? TourScheduleId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal CommissionAmount { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal CommissionRate { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string CommissionType { get; set; }

        [Required]
        public DateTime CalculationDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 