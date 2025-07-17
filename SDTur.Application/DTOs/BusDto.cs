namespace SDTur.Application.DTOs
{
    public class BusDto
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