namespace SDTur.Web.Models.Master.Accommodation
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; }
    }
} 