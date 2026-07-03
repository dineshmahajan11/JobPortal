using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJobService
    {
        List<Job> GetAllJobs();

        Job CreateJob(CreateJobDto dto, int recruiterId);

        Job? GetJobById(int id);

        Job? UpdateJob(int id, CreateJobDto dto, int recruiterId);

        bool DeleteJob(int id);
        List<RecruiterJobDto> GetRecruiterJobs(int recruiterId);

    }
}