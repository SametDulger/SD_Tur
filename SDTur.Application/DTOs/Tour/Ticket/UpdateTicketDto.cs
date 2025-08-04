using System;
using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Tour.Ticket
{
    public class UpdateTicketDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public DateTime TourDate { get; set; }
        
        [Required]
        public string? CustomerName { get; set; }
        
        public string? Nationality { get; set; }
        
        public string? RoomNumber { get; set; }
        
        public bool RequiresService { get; set; }
        
        [Required]
        public int FullCount { get; set; }
        
        [Required]
        public int HalfCount { get; set; }
        
        [Required]
        public int GuestCount { get; set; }
        
        [Required]
        public decimal TotalAmount { get; set; }
        
        [Required]
        public decimal PaidAmount { get; set; }
        
        [Required]
        public string? Currency { get; set; }
        
        public string? Notes { get; set; }
        
        public bool IsPassTicket { get; set; }
        
        public int? HotelId { get; set; }
        
        public int? TourScheduleId { get; set; }
        
        [Required]
        public int BranchId { get; set; }
    }
} 