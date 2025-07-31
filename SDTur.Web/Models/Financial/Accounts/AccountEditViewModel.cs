using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        
        [Required]
        public string AccountName { get; set; } = string.Empty;
        
        [Required]
        public string AccountType { get; set; } = string.Empty;
        
        public string ContactPerson { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public decimal Balance { get; set; }
        
        public decimal CurrentBalance { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
        
        [Display(Name = "Para Birimi")]
        public int? CurrencyId { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime? CreatedDate { get; set; }
        
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
    }
} 