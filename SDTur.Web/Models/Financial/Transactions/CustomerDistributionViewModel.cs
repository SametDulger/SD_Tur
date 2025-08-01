using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Transactions
{
    public class CustomerDistributionViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DistributionDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 