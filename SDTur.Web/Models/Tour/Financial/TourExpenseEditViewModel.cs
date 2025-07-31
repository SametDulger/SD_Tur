using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Financial
{
    public class TourExpenseEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int TourScheduleId { get; set; }
        [Required]
        public string ExpenseType { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public string Currency { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 