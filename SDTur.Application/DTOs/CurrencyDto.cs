using System.ComponentModel.DataAnnotations;

namespace SDTur.Application.DTOs
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateCurrencyDto
    {
        [Required(ErrorMessage = "Para birimi adı zorunludur")]
        [StringLength(50, ErrorMessage = "Para birimi adı en fazla 50 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Para birimi kodu zorunludur")]
        [StringLength(3, ErrorMessage = "Para birimi kodu en fazla 3 karakter olabilir")]
        public string Code { get; set; }

        [StringLength(5, ErrorMessage = "Sembol en fazla 5 karakter olabilir")]
        public string Symbol { get; set; }
    }

    public class UpdateCurrencyDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Para birimi adı zorunludur")]
        [StringLength(50, ErrorMessage = "Para birimi adı en fazla 50 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Para birimi kodu zorunludur")]
        [StringLength(3, ErrorMessage = "Para birimi kodu en fazla 3 karakter olabilir")]
        public string Code { get; set; }

        [StringLength(5, ErrorMessage = "Sembol en fazla 5 karakter olabilir")]
        public string Symbol { get; set; }

        public bool IsActive { get; set; }
    }
} 