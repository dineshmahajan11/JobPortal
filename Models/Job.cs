namespace JobPortal.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public int RecruiterId { get; set; }

        public ICollection<JobApplication> Applications { get; set; }
        = new List<JobApplication>();
        public User Recruiter { get; set; } = null!;
    }
}