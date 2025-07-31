using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Financial.Reports
{
    public class FinancialReportEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rapor adı zorunludur")]
        [Display(Name = "Rapor Adı")]
        public string ReportName { get; set; }

        [Required(ErrorMessage = "Rapor tipi zorunludur")]
        [Display(Name = "Rapor Tipi")]
        public string ReportType { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Parametreler")]
        public string Parameters { get; set; }

        [Display(Name = "Oluşturan")]
        public string GeneratedBy { get; set; }

        [Display(Name = "Dosya Yolu")]
        public string FilePath { get; set; }

        [Display(Name = "Dosya Tipi")]
        public string FileType { get; set; }

        [Display(Name = "Çalışan ID")]
        public int? EmployeeId { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}