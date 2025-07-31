using System;
using System.Collections.Generic;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.Tour;

namespace SDTur.Core.Entities.Financial
{
    public class AccountTransaction : BaseEntity
    {
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } // Debit, Credit
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Foreign keys
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        
        // Navigation properties
        public virtual Account Account { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual PassCompany PassCompany { get; set; }
    }
} 