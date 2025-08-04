using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.PassCompany
{
    public class CreatePassCompanyDto
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? ContactPerson { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? Address { get; set; }
    }
} 