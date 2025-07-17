using System;
using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class TourSchedule : BaseEntity
    {
        public DateTime TourDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; }
        
        // Foreign keys
        public int TourId { get; set; }
        
        // Navigation properties
        public virtual Tour Tour { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TourExpense> TourExpenses { get; set; }
        public virtual ICollection<TourIncome> TourIncomes { get; set; }
        public virtual ICollection<CommissionCalculation> CommissionCalculations { get; set; }
    }
} 