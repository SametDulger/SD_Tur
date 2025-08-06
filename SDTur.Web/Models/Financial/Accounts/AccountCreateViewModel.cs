using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Accounts
{
    public class AccountCreateViewModel
    {
        [Required(ErrorMessage = "Hesap numarası zorunludur")]
        [StringLength(50, ErrorMessage = "Hesap numarası en fazla 50 karakter olabilir")]
        [Display(Name = "Hesap Numarası")]
        public string AccountNumber { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Hesap adı zorunludur")]
        [StringLength(100, ErrorMessage = "Hesap adı en fazla 100 karakter olabilir")]
        [Display(Name = "Hesap Adı")]
        public string AccountName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Hesap tipi zorunludur")]
        [StringLength(50, ErrorMessage = "Hesap tipi en fazla 50 karakter olabilir")]
        [Display(Name = "Hesap Tipi")]
        public string AccountType { get; set; } = string.Empty;
        
        [Range(0, double.MaxValue, ErrorMessage = "Bakiye 0'dan küçük olamaz")]
        [Display(Name = "Bakiye")]
        public decimal Balance { get; set; } = 0;
        
        [Required(ErrorMessage = "Para birimi zorunludur")]
        [StringLength(3, ErrorMessage = "Para birimi en fazla 3 karakter olabilir")]
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
        
        [Range(0, double.MaxValue, ErrorMessage = "Başlangıç bakiyesi 0'dan küçük olamaz")]
        [Display(Name = "Başlangıç Bakiyesi")]
        public decimal InitialBalance { get; set; }
        
        [StringLength(500, ErrorMessage = "Adres en fazla 500 karakter olabilir")]
        [Display(Name = "Adres")]
        public string Address { get; set; } = string.Empty;
        
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Para birimi seçimi zorunludur")]
        [Display(Name = "Para Birimi")]
        public int CurrencyId { get; set; }
        
        [Required(ErrorMessage = "İletişim kişisi zorunludur")]
        [StringLength(100, ErrorMessage = "İletişim kişisi en fazla 100 karakter olabilir")]
        [Display(Name = "İletişim Kişisi")]
        public string ContactPerson { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Telefon zorunludur")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        [RegularExpression(@"^[0-9+\-\s()]*$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
    }
} 