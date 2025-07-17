using System;

namespace SDTur.Core.Entities
{
    public class Cash : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } // Income, Expense
        public decimal Amount { get; set; }
        public string Currency { get; set; } // USD, EUR, TRY
        public string Description { get; set; }
        public string Category { get; set; } // Ticket, Commission, Tour, Manual
        public bool IsAutomatic { get; set; } // Otomatik mi manuel mi?
        public bool IsActive { get; set; } = true;
        
        // Foreign keys
        public int? TicketId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PassCompanyId { get; set; }
        
        // Navigation properties
        public virtual Ticket Ticket { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PassCompany PassCompany { get; set; }
    }
} 