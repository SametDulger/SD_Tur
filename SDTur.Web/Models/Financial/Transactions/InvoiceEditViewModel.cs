using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class InvoiceEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura numarası zorunludur")]
        [Display(Name = "Fatura Numarası")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Fatura tarihi zorunludur")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Vade tarihi zorunludur")]
        [Display(Name = "Vade Tarihi")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Display(Name = "Toplam Tutar")]
        [Range(0, double.MaxValue, ErrorMessage = "Toplam tutar 0'dan büyük olmalıdır")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Para birimi zorunludur")]
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        [Display(Name = "Durum")]
        public string Status { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        public string Description { get; set; }

        [Display(Name = "Notlar")]
        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string Notes { get; set; }

        [Display(Name = "Pas Şirketi ID")]
        public int? PassCompanyId { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}