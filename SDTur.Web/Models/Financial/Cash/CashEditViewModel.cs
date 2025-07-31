using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Cash
{
    public class CashEditViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string Currency { get; set; } = string.Empty;
        
        [Required]
        public string TransactionType { get; set; } = string.Empty;
        
        [Display(Name = "Nakit Tipi")]
        public string CashType { get; set; } = string.Empty;
        
        [Display(Name = "Kategori")]
        public string Category { get; set; } = string.Empty;
        
        [Display(Name = "Otomatik")]
        public bool IsAutomatic { get; set; }
        
        [Display(Name = "Onaylandı")]
        public bool IsApproved { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime TransactionDate { get; set; }
        
        [Display(Name = "Onay Tarihi")]
        public DateTime? ApprovalDate { get; set; }
        
        [Display(Name = "Onaylayan")]
        public string ApprovedBy { get; set; } = string.Empty;
        
        public int? TicketId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PassCompanyId { get; set; }
        
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Makbuz Numarası")]
        public string ReceiptNumber { get; set; } = string.Empty;
    }
} 