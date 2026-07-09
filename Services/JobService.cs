using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;
using AutoMapper;


namespace JobPortal.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public List<JobDto> GetAllJobs()
        {
            var jobs = _jobRepository.GetAll();

            return _mapper.Map<List<JobDto>>(jobs);
        }

        public JobDto CreateJob(CreateJobDto dto, int recruiterId)
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

            var createdJob = _jobRepository.Add(job);

            return _mapper.Map<JobDto>(createdJob);
        }

        public JobDto? GetJobById(int id)
        {
            var job = _jobRepository.GetById(id);

            if (job == null)
                return null;

            return _mapper.Map<JobDto>(job);
        }

        public JobDto? UpdateJob(int id, CreateJobDto dto, int recruiterId)
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

            var updatedJob = _jobRepository.Update(job);

            return _mapper.Map<JobDto>(updatedJob);
        }

        public bool DeleteJob(int id)
        {
            return _jobRepository.Delete(id);
        }

        public List<RecruiterJobDto> GetRecruiterJobs(int recruiterId)
        {
            return _jobRepository.GetRecruiterJobs(recruiterId);
        }
        public PagedResultDto<JobDto> Search(
        string? keyword,
        string? location,
        int page,
        int pageSize)
        {
            return _jobRepository.Search(keyword, location, page, pageSize);
        }

    }
}