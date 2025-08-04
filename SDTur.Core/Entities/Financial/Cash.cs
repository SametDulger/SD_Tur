using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class Cash : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty; // Income, Expense
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty; // USD, EUR, TRY
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Ticket, Commission, Tour, Manual
        public bool IsAutomatic { get; set; } // Otomatik mi manuel mi?
        
        // Foreign keys
        public int? TicketId { get; set; }
        public int? TourScheduleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PassCompanyId { get; set; }
        
        // Navigation properties
        public virtual Ticket? Ticket { get; set; }
        public virtual TourSchedule? TourSchedule { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual PassCompany? PassCompany { get; set; }
    }
} 