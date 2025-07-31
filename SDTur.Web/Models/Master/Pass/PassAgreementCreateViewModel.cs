using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Master.Pass
{
    public class PassAgreementCreateViewModel
    {
        [Required]
        public int PassCompanyId { get; set; }
        [Required]
        public string AgreementNumber { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal CommissionRate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Terms { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 