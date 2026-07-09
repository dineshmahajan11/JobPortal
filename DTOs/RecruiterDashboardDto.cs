namespace JobPortal.DTOs
{
    public class RecruiterDashboardDto
    {
        public int TotalJobs { get; set; }

        public int TotalApplications { get; set; }

        public int PendingApplications { get; set; }

        public int ShortlistedApplications { get; set; }

        public int RejectedApplications { get; set; }
    }
}