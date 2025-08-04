using System;
using System.Collections.Generic;
using SDTur.Application.DTOs.Tour.Ticket;
using SDTur.Application.DTOs.Tour.TourExpense;
using SDTur.Application.DTOs.Tour.TourIncome;
using SDTur.Application.DTOs.Master.Bus;

namespace SDTur.Application.DTOs.Tour.TourSchedule
{
    public class TourScheduleDetailDto
    {
        public int Id { get; set; }
        public DateTime TourDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public List<TicketDto> Tickets { get; set; } = new List<TicketDto>();
        public List<TourExpenseDto> Expenses { get; set; } = new List<TourExpenseDto>();
        public List<TourIncomeDto> Incomes { get; set; } = new List<TourIncomeDto>();
        public List<BusDto> AssignedBuses { get; set; } = new List<BusDto>();
    }
}