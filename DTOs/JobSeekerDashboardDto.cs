namespace JobPortal.DTOs
{
    public class JobSeekerDashboardDto
    {
        public int AppliedJobs { get; set; }

        public int SavedJobs { get; set; }

        public int ShortlistedJobs { get; set; }

        public bool ResumeUploaded { get; set; }
    }
}