using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class UpdateSystemLogDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        [Required]
        public string LogLevel { get; set; }

        [Required]
        public string Message { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public string Action { get; set; }

        public int? UserId { get; set; }

        public int? EmployeeId { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public bool IsActive { get; set; }
    }
} 