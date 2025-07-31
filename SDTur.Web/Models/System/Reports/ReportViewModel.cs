using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.System.Reports
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Rapor Adı")]
        public string ReportName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Rapor Tipi")]
        public string ReportType { get; set; } = string.Empty;

        [Display(Name = "Oluşturan")]
        public string CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = string.Empty;

        [Display(Name = "Rapor Tarihi")]
        public DateTime ReportDate { get; set; }

        [Display(Name = "Parametreler")]
        public string Parameters { get; set; } = string.Empty;

        [Display(Name = "Oluşturan")]
        public string GeneratedBy { get; set; } = string.Empty;

        [Display(Name = "Dosya Yolu")]
        public string FilePath { get; set; } = string.Empty;

        [Display(Name = "Dosya Tipi")]
        public string FileType { get; set; } = string.Empty;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
} 