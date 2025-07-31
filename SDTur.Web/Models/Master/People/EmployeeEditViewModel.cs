using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.People
{
    public class EmployeeEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        public DateTime HireDate { get; set; }
        
        [Required]
        public string Position { get; set; } = string.Empty;
        
        public int? BranchId { get; set; }
        
        [Display(Name = "Para Birimi")]
        public int? CurrencyId { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        [Display(Name = "Komisyon Oranı")]
        public decimal CommissionRate { get; set; }
        
        public string Address { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
    }
} 