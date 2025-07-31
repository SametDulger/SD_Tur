using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs.Master.Nationality
{
    public class UpdateNationalityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uyruk adı zorunludur")]
        [StringLength(50, ErrorMessage = "Uyruk adı en fazla 50 karakter olabilir")]
        public string Name { get; set; }

        [StringLength(3, ErrorMessage = "Kod en fazla 3 karakter olabilir")]
        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
} 