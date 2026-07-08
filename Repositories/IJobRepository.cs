using JobPortal.DTOs;
using JobPortal.Models;



namespace JobPortal.Repositories
{
    public interface IJobRepository
    {
        List<Job> GetAll();

        Job Add(Job job);
        Job? GetById(int id);

        Job Update(Job job);

        bool Delete(int id);
        List<RecruiterJobDto> GetRecruiterJobs(int recruiterId);
        PagedResultDto<JobDto> Search(
        string? keyword,
        string? location,
        int page,
        int pageSize);


    }
}