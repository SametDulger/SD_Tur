using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Tour.Core
{
    public class TourTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 