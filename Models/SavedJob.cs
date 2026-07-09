namespace JobPortal.Models
{
    public class SavedJob
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }

        public DateTime SavedDate { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;

        public Job Job { get; set; } = null!;
    }
}