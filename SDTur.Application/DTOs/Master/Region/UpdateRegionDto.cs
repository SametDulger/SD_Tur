namespace SDTur.Application.DTOs.Master.Region
{
    public class UpdateRegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceFromKemer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
} 