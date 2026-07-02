using JobPortal.Data;
using JobPortal.Models;

namespace JobPortal.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public JobApplication Add(JobApplication application)
        {
            _context.JobApplications.Add(application);
            _context.SaveChanges();

            return application;
        }

        public bool AlreadyApplied(int jobId, int userId)
        {
            return _context.JobApplications
                .Any(a => a.JobId == jobId && a.UserId == userId);
        }

        public List<JobApplication> GetByUserId(int userId)
        {
            return _context.JobApplications
                .Where(a => a.UserId == userId)
                .ToList();
        }
    }
}