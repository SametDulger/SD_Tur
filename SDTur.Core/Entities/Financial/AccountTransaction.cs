using System;
using System.Collections.Generic;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.Tour;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Core.Entities.Financial
{
    public class AccountTransaction : BaseEntity
    {
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty; // Debit, Credit
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        
        // Foreign keys
        public int? TourScheduleId { get; set; }
        public int? TicketId { get; set; }
        public int? PassCompanyId { get; set; }
        
        // Navigation properties
        public virtual Account Account { get; set; } = null!;
        public virtual TourSchedule? TourSchedule { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual PassCompany? PassCompany { get; set; }
    }
} 