using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Bilet Numarası")]
        public string TicketNumber { get; set; } = string.Empty;
        
        [Display(Name = "Tur Tarihi")]
        public DateTime TourDate { get; set; }
        
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Display(Name = "Uyruk")]
        public string Nationality { get; set; } = string.Empty;
        
        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; } = string.Empty;
        
        [Display(Name = "Servis Gerekli")]
        public bool RequiresService { get; set; }
        
        [Display(Name = "Tam Sayı")]
        public int FullCount { get; set; }
        
        [Display(Name = "Yarım Sayı")]
        public int HalfCount { get; set; }
        
        [Display(Name = "Misafir Sayı")]
        public int GuestCount { get; set; }
        
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Ödenen Tutar")]
        public decimal PaidAmount { get; set; }
        
        [Display(Name = "Kalan Tutar")]
        public decimal RestAmount { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        [Display(Name = "İptal Edildi")]
        public bool IsCancelled { get; set; }
        
        [Display(Name = "Pas Bileti")]
        public bool IsPassTicket { get; set; }
        
        [Display(Name = "Gelen Pas")]
        public bool IsIncomingPass { get; set; }
        
        [Display(Name = "Satış Tarihi")]
        public DateTime SaleDate { get; set; }
        
        [Display(Name = "İptal Tarihi")]
        public DateTime? CancellationDate { get; set; }
        
        // Foreign keys
        public int TourId { get; set; }
        public int BranchId { get; set; }
        public int EmployeeId { get; set; }
        public int HotelId { get; set; }
        public int? ServiceScheduleId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? BusId { get; set; }
        public int? PassCompanyId { get; set; }
        
        // Navigation properties for display
        public string TourName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public string BusPlateNumber { get; set; } = string.Empty;
        public string PassCompanyName { get; set; } = string.Empty;
    }
} 