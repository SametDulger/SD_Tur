namespace SDTur.Application.DTOs.Master.Bus
{
    public class CreateBusDto
    {
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public bool IsOwned { get; set; }
    }
} 