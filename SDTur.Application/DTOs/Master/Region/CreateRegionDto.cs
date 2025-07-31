namespace SDTur.Application.DTOs.Master.Region
{
    public class CreateRegionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceFromKemer { get; set; }
        public int Order { get; set; }
    }
} 