namespace JobPortal.DTOs
{
    public class RecruiterJobDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public int TotalApplications { get; set; }
    }
}