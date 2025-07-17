using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities
{
    public class Ticket : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string TicketNumber { get; set; }

        public DateTime TourDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(20)]
        public string RoomNumber { get; set; }

        public bool RequiresService { get; set; }

        public int FullCount { get; set; } // Tam ücret ödeyenler
        public int HalfCount { get; set; } // Yarım ücret ödeyenler (çocuklar)
        public int GuestCount { get; set; } // Ücretsiz misafirler

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RestAmount { get; set; }

        [StringLength(3)]
        public string Currency { get; set; } // USD, EUR, TRY

        [StringLength(500)]
        public string Notes { get; set; }

        public bool IsCancelled { get; set; }
        public bool IsPassTicket { get; set; } // Pas bileti mi?
        public bool IsIncomingPass { get; set; } // Gelen pas mı?

        public DateTime SaleDate { get; set; }
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

        // Navigation properties
        public virtual Tour Tour { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ServiceSchedule ServiceSchedule { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual PassCompany PassCompany { get; set; }
        public virtual ICollection<CommissionCalculation> CommissionCalculations { get; set; }
    }
} 