namespace JobPortal.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; }

        public string Status { get; set; } = "Applied";
        public Job Job { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}