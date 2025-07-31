namespace SDTur.Web.Models.Master.Transport
{
    public class BusViewModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int Year { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string DriverPhone { get; set; } = string.Empty;
        public bool IsOwned { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastMaintenance { get; set; }
    }
} 