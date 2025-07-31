using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Nationality
{
    public class NationalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
} 