using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class UpdateCashDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        public bool IsAutomatic { get; set; }

        public int? TicketId { get; set; }

        public int? TourScheduleId { get; set; }

        public int? EmployeeId { get; set; }

        public int? PassCompanyId { get; set; }
    }
} 