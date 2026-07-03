namespace JobPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "JobSeeker";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<JobApplication> Applications { get; set; }
    = new List<JobApplication>();
    }
}