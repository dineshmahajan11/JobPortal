using AutoMapper;
using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;

namespace JobPortal.Services
{
    public class SavedJobService : ISavedJobService
    {
        private readonly ISavedJobRepository _savedJobRepository;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;

        public SavedJobService(
            ISavedJobRepository savedJobRepository,
            IJobRepository jobRepository,
            IMapper mapper)
        {
            _savedJobRepository = savedJobRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public bool SaveJob(int jobId, int userId)
        {
            var job = _jobRepository.GetById(jobId);

            if (job == null)
                return false;

            if (_savedJobRepository.AlreadySaved(jobId, userId))
                return false;

            var savedJob = new SavedJob
            {
                JobId = jobId,
                UserId = userId,
                SavedDate = DateTime.UtcNow
            };

            _savedJobRepository.Add(savedJob);

            return true;
        }

        public List<JobDto> GetSavedJobs(int userId)
        {
            var savedJobs = _savedJobRepository.GetByUserId(userId);

            return savedJobs
                .Select(s => _mapper.Map<JobDto>(s.Job))
                .ToList();
        }

        public bool RemoveSavedJob(int jobId, int userId)
        {
            return _savedJobRepository.Remove(jobId, userId);
        }
    }
}