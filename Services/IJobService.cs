using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJobService
    {
        List<Job> GetAllJobs();

        Job CreateJob(CreateJobDto dto);
    }
}