using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IJobApplicationRepository
    {
        JobApplication Add(JobApplication application);

        bool AlreadyApplied(int jobId, int userId);

        List<JobApplication> GetByUserId(int userId);
    }
}