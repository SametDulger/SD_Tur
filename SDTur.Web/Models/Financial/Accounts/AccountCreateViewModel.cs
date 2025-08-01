using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountCreateViewModel
    {
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        
        [Required]
        public string AccountName { get; set; } = string.Empty;
        
        [Required]
        public string AccountType { get; set; } = string.Empty;
        
        public decimal Balance { get; set; } = 0;
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Başlangıç Bakiyesi")]
        public decimal InitialBalance { get; set; }
        
        [Display(Name = "Adres")]
        public string Address { get; set; } = string.Empty;
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Para Birimi")]
        public int? CurrencyId { get; set; }
        
        [Display(Name = "İletişim Kişisi")]
        public string ContactPerson { get; set; } = string.Empty;
        
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
    }
} 