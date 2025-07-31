namespace SDTur.Web.Models.Tour.Core
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime TourDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsActive { get; set; }
    }
}