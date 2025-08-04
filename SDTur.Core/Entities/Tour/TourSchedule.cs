using System;
using SDTur.Core.Entities.Core;
using SDTur.Core.Entities.Financial;
using System.Collections.Generic;

namespace SDTur.Core.Entities.Tour
{
    public class TourSchedule : BaseEntity
    {
        public DateTime TourDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; } = string.Empty;
        
        // Foreign keys
        public int TourId { get; set; }
        
        // Navigation properties
        public virtual Tour Tour { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<TourExpense> TourExpenses { get; set; } = new List<TourExpense>();
        public virtual ICollection<TourIncome> TourIncomes { get; set; } = new List<TourIncome>();
        public virtual ICollection<CommissionCalculation> CommissionCalculations { get; set; } = new List<CommissionCalculation>();
    }
} 