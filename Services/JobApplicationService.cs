using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;

namespace JobPortal.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public JobApplication Apply(ApplyJobDto dto, int userId)
        {
            if (_repository.AlreadyApplied(dto.JobId, userId))
            {
                throw new Exception("You have already applied for this job.");
            }

            var application = new JobApplication
            {
                JobId = dto.JobId,
                UserId = userId,
                AppliedDate = DateTime.UtcNow,
                Status = "Applied"
            };

            return _repository.Add(application);
        }

        public List<JobApplication> GetMyApplications(int userId)
        {
            return _repository.GetByUserId(userId);
        }
    }
}