namespace SDTur.Application.DTOs.Master.Bus
{
    public class UpdateBusDto
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public bool IsOwned { get; set; }
        public bool IsActive { get; set; }
    }
} 