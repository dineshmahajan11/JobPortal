using JobPortal.Data;
using JobPortal.DTOs;

namespace JobPortal.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RecruiterDashboardDto GetRecruiterDashboard(int recruiterId)
        {
            var recruiterJobs = _context.Jobs
                .Where(j => j.RecruiterId == recruiterId);

            var jobIds = recruiterJobs
                .Select(j => j.Id)
                .ToList();

            var applications = _context.JobApplications
                .Where(a => jobIds.Contains(a.JobId));

            return new RecruiterDashboardDto
            {
                TotalJobs = recruiterJobs.Count(),

                TotalApplications = applications.Count(),

                PendingApplications =
                    applications.Count(a => a.Status == "Pending"),

                ShortlistedApplications =
                    applications.Count(a => a.Status == "Shortlisted"),

                RejectedApplications =
                    applications.Count(a => a.Status == "Rejected")
            };
        }

        public JobSeekerDashboardDto GetJobSeekerDashboard(int userId)
        {
            return new JobSeekerDashboardDto
            {
                AppliedJobs =
                    _context.JobApplications
                        .Count(a => a.UserId == userId),

                SavedJobs =
                    _context.SavedJobs
                        .Count(s => s.UserId == userId),

                ShortlistedJobs =
                    _context.JobApplications
                        .Count(a =>
                            a.UserId == userId &&
                            a.Status == "Shortlisted"),

                ResumeUploaded =
                    _context.Users
                        .Any(u =>
                            u.Id == userId &&
                            u.ResumeUrl != null)
            };
        }
    }
}