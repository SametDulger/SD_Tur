using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Operations
{
    public class TicketCreateViewModel
    {
        [Required]
        [Display(Name = "Bilet Numarası")]
        public string TicketNumber { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Tur Tarihi")]
        public DateTime TourDate { get; set; }
        
        [Required]
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
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
        
        [Required]
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
        
        [Display(Name = "Ödenen Tutar")]
        public decimal PaidAmount { get; set; }
        
        [Display(Name = "Para Birimi")]
        public string Currency { get; set; } = string.Empty;
        
        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;
        
        [Display(Name = "Pas Bileti")]
        public bool IsPassTicket { get; set; }
        
        [Display(Name = "Gelen Pas")]
        public bool IsIncomingPass { get; set; }
        
        // Foreign keys
        [Required]
        public int TourId { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        
        public int? ServiceScheduleId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? BusId { get; set; }
        public int? PassCompanyId { get; set; }
    }
} 