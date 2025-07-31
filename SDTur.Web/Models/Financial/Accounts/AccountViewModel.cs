using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        
        public string AccountNumber { get; set; } = string.Empty;
        
        public string AccountName { get; set; } = string.Empty;
        
        public string AccountType { get; set; } = string.Empty;
        
        public string ContactPerson { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public decimal Balance { get; set; }
        
        public decimal CurrentBalance { get; set; }
        
        public string Currency { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Toplam İşlem")]
        public int TotalTransactions { get; set; }
        
        [Display(Name = "Bu Ay İşlem")]
        public int ThisMonthTransactions { get; set; }
        
        [Display(Name = "Toplam Gelir")]
        public decimal TotalIncome { get; set; }
        
        [Display(Name = "Toplam Gider")]
        public decimal TotalExpense { get; set; }
        
        [Display(Name = "Aktif İşlem Var")]
        public bool HasActiveTransactions { get; set; }
    }
} 