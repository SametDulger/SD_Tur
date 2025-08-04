namespace SDTur.Web.Models.Home
{
    public class DashboardViewModel
    {
        public List<RecentTourViewModel> RecentTours { get; set; } = new List<RecentTourViewModel>();
        public List<UpcomingTourViewModel> UpcomingTours { get; set; } = new List<UpcomingTourViewModel>();
        public List<RecentActivityViewModel> RecentActivities { get; set; } = new List<RecentActivityViewModel>();
        
        // Statistics
        public int TotalTours { get; set; }
        public int ActiveTours { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }
    }

    public class RecentTourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class UpcomingTourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; } = string.Empty;
    }

    public class RecentActivityViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } = string.Empty;
    }
} 