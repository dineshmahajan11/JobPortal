namespace JobPortal.DTOs
{
    public class ApplicantDto
    {
        public int ApplicationId { get; set; }

        public string ApplicantName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime AppliedDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}