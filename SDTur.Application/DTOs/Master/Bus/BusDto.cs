namespace SDTur.Application.DTOs.Master.Bus
{
    public class BusDto
    {
        public int Id { get; set; }
        public string? PlateNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Capacity { get; set; }
        public int Year { get; set; }
        public string? DriverName { get; set; }
        public string? DriverPhone { get; set; }
        public string? DriverLicense { get; set; }
        public DateTime LastMaintenance { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public int TotalTours { get; set; }
        public int TotalPassengers { get; set; }
        public decimal TotalRevenue { get; set; }
        public bool HasActiveTours { get; set; }
        public bool IsOwned { get; set; }
        public bool IsActive { get; set; }
    }
} 