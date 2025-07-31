using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Financial
{
    public class TourIncomeCreateViewModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public string IncomeType { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime IncomeDate { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
        public bool IsReceived { get; set; } = false;
    }
} 