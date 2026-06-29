using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;

namespace JobPortal.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public List<Job> GetAllJobs()
        {
            return _jobRepository.GetAll();
        }

        public Job CreateJob(CreateJobDto dto)
        {
            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Salary = dto.Salary,
                CompanyName = dto.CompanyName,
                RecruiterId = dto.RecruiterId,
                CreatedDate = DateTime.UtcNow
            };

            return _jobRepository.Add(job);
        }
    }
}