using JobPortal.DTOs;

namespace JobPortal.Services
{
    public interface ISavedJobService
    {
        bool SaveJob(int jobId, int userId);

        List<JobDto> GetSavedJobs(int userId);

        bool RemoveSavedJob(int jobId, int userId);
    }
}