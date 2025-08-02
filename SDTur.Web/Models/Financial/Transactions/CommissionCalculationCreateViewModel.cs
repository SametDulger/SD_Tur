using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class CommissionCalculationCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public decimal CommissionRate { get; set; }
        
        [Required]
        public decimal BaseAmount { get; set; }
        
        [Required]
        public decimal CommissionAmount { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime CalculationDate { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "Hesaplama Tipi")]
        public string CalculationType { get; set; } = string.Empty;
        
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Komisyon Tipi")]
        public string CommissionType { get; set; } = string.Empty;
        
        [Display(Name = "Tur Programı")]
        public int? TourScheduleId { get; set; }
        
        [Display(Name = "Bilet")]
        public int? TicketId { get; set; }
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
    }
}