using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Reports
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Rapor Adı")]
        public string ReportName { get; set; }

        [Display(Name = "Rapor Tipi")]
        public string ReportType { get; set; }

        [Display(Name = "Rapor Tarihi")]
        public DateTime ReportDate { get; set; }

        [Display(Name = "Parametreler")]
        public string Parameters { get; set; }

        [Display(Name = "Oluşturan")]
        public string GeneratedBy { get; set; }

        [Display(Name = "Dosya Yolu")]
        public string FilePath { get; set; }

        [Display(Name = "Dosya Tipi")]
        public string FileType { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 