using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.People
{
    public class EmployeeViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;
        
        public string Position { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Display(Name = "Şube Adı")]
        public string BranchName { get; set; } = string.Empty;
        
        [Display(Name = "İşe Başlama Tarihi")]
        public DateTime HireDate { get; set; }
        
        [Display(Name = "Maaş")]
        public decimal Salary { get; set; }
        
        [Display(Name = "Komisyon Oranı")]
        public decimal CommissionRate { get; set; }
        
        public int? CurrencyId { get; set; }
        public int? BranchId { get; set; }
    }
} 