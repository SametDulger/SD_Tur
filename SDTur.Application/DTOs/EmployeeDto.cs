using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime HireDate { get; set; }
        public decimal CommissionRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public BranchDto Branch { get; set; }
    }

    public class CreateEmployeeDto
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Position { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        public int CurrencyId { get; set; }
        
        [Required]
        public DateTime HireDate { get; set; }
        
        [Required]
        public decimal CommissionRate { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        
        public bool IsActive { get; set; } = true;
    }

    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime HireDate { get; set; }
        public decimal CommissionRate { get; set; }
        public int BranchId { get; set; }
        public bool IsActive { get; set; }
    }
} 