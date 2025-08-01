using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class CommissionCalculationViewModel
    {
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        public string EmployeeName { get; set; } = string.Empty;
        
        public int TourId { get; set; }
        
        public string TourName { get; set; } = string.Empty;
        
        public decimal CommissionAmount { get; set; }
        
        public decimal CommissionRate { get; set; }
        
        public DateTime CalculationDate { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public bool IsPaid { get; set; }
        
        [Display(Name = "Hesaplama Tipi")]
        public string CalculationType { get; set; } = string.Empty;
        
        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
    }
} 