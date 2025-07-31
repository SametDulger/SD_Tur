using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.CustomerDistribution
{
    public class CreateCustomerDistributionDto
    {
        [Required]
        public DateTime DistributionDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string Notes { get; set; }

        [Required]
        public int TourScheduleId { get; set; }

        [Required]
        public int BusId { get; set; }

        [Required]
        public int TicketId { get; set; }

        public int? EmployeeId { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 