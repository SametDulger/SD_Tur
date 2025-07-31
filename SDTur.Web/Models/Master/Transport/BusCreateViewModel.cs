using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Transport
{
    public class BusCreateViewModel
    {
        [Required]
        public string PlateNumber { get; set; } = string.Empty;
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Year { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string DriverPhone { get; set; } = string.Empty;
        public bool IsOwned { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastMaintenance { get; set; }
    }
} 