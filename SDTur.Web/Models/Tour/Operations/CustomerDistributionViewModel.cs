namespace SDTur.Web.Models.Tour.Operations
{
    public class CustomerDistributionViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string DistributionType { get; set; } = string.Empty;
        public DateTime DistributionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
} 