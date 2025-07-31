using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.Tour;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Financial
{
    public class CommissionCalculation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int TourScheduleId { get; set; }
        public int TicketId { get; set; }
        public DateTime CalculationDate { get; set; }
        public decimal CommissionAmount { get; set; }
        public string Currency { get; set; }
        public string CommissionType { get; set; } // Percentage, Fixed
        public decimal CommissionRate { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual Employee Employee { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
} 