using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string AccountType { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [Range(0, double.MaxValue)]
        public decimal CurrentBalance { get; set; }

        [Required]
        public string Currency { get; set; }

        public bool IsActive { get; set; }
    }
} 