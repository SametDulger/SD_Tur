using System;

namespace SDTur.Application.DTOs.Tour.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime TourDate { get; set; }
        public DateTime TicketDate { get; set; }
        public string CustomerName { get; set; }
        public string Nationality { get; set; }
        public string RoomNumber { get; set; }
        public bool RequiresService { get; set; }
        public int FullCount { get; set; }
        public int HalfCount { get; set; }
        public int GuestCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Currency { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsPassTicket { get; set; }
        public int? HotelId { get; set; }
        public int? TourScheduleId { get; set; }
        public int BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public string HotelName { get; set; }
        public string TourName { get; set; }
        public string BranchName { get; set; }
    }
} 