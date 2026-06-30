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

        public Job CreateJob(CreateJobDto dto, int recruiterId)
        {
            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Salary = dto.Salary,
                CompanyName = dto.CompanyName,
                RecruiterId = recruiterId,
                CreatedDate = DateTime.UtcNow
            };

            return _jobRepository.Add(job);
        }

        public Job? GetJobById(int id)
        {
            return _jobRepository.GetById(id);
        }

        public Job? UpdateJob(int id, CreateJobDto dto, int recruiterId)
        {
            var job = _jobRepository.GetById(id);

            if (job == null)
                return null;

            job.Title = dto.Title;
            job.Description = dto.Description;
            job.Location = dto.Location;
            job.CompanyName = dto.CompanyName;
            job.Salary = dto.Salary;
            job.RecruiterId = recruiterId;

            return _jobRepository.Update(job);
        }

        public bool DeleteJob(int id)
        {
            return _jobRepository.Delete(id);
        }
    }
}