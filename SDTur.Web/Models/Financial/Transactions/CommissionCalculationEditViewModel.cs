using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class CommissionCalculationEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hesaplama tarihi zorunludur")]
        [Display(Name = "Hesaplama Tarihi")]
        public DateTime CalculationDate { get; set; }

        [Required(ErrorMessage = "Komisyon oranı zorunludur")]
        [Display(Name = "Komisyon Oranı (%)")]
        [Range(0, 100, ErrorMessage = "Komisyon oranı 0-100 arasında olmalıdır")]
        public decimal CommissionRate { get; set; }

        [Required(ErrorMessage = "Komisyon tutarı zorunludur")]
        [Display(Name = "Komisyon Tutarı")]
        [Range(0, double.MaxValue, ErrorMessage = "Komisyon tutarı 0'dan büyük olmalıdır")]
        public decimal CommissionAmount { get; set; }

        [Required(ErrorMessage = "Para birimi zorunludur")]
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; }

        [Display(Name = "Çalışan ID")]
        public int? EmployeeId { get; set; }

        [Display(Name = "Tur Programı ID")]
        public int? TourScheduleId { get; set; }

        [Display(Name = "Bilet ID")]
        public int? TicketId { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}