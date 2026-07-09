using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJobService
    {
        List<JobDto> GetAllJobs();

        JobDto CreateJob(CreateJobDto dto, int recruiterId);

        JobDto? GetJobById(int id);

        JobDto? UpdateJob(int id, CreateJobDto dto, int recruiterId);

        bool DeleteJob(int id);
        List<RecruiterJobDto> GetRecruiterJobs(int recruiterId);
        PagedResultDto<JobDto> Search(
        string? keyword,
        string? location,
        int page,
        int pageSize);

    }
}