using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Employee
{
    public class UpdateEmployeeDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? FirstName { get; set; }
        
        [Required]
        public string? LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        public string? Position { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        public string? Currency { get; set; }
        
        public string? CurrencyCode { get; set; }
        
        [Required]
        public DateTime HireDate { get; set; }
        
        [Required]
        public decimal CommissionRate { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        
        public bool IsActive { get; set; }
    }
} 