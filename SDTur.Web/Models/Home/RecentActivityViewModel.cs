using System.ComponentModel.DataAnnotations;

namespace SDTur.Web.Models.Home
{
    public class RecentActivityViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
} 