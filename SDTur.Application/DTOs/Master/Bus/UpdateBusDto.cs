using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Bus
{
    public class UpdateBusDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? PlateNumber { get; set; }
        
        [Required]
        public string? Brand { get; set; }
        
        [Required]
        public string? Model { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        public string? DriverName { get; set; }
        
        public string? DriverPhone { get; set; }
        
        public bool IsOwned { get; set; }
        
        public bool IsActive { get; set; }
    }
} 