using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Financial.Account
{
    public class CreateAccountDto
    {
        [Required]
        public string? AccountNumber { get; set; }

        [Required]
        public string? AccountName { get; set; }

        [Required]
        public string? AccountType { get; set; }

        [Required]
        public string? ContactPerson { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }

        [Range(0, double.MaxValue)]
        public decimal CurrentBalance { get; set; }

        [Required]
        public string? Currency { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 