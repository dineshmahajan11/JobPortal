using JobPortal.Data;
using JobPortal.Models;
using Microsoft.EntityFrameworkCore;
using JobPortal.DTOs;

namespace JobPortal.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public JobApplication Add(JobApplication application)
        {
            _context.JobApplications.Add(application);
            _context.SaveChanges();

            return application;
        }

        public bool AlreadyApplied(int jobId, int userId)
        {
            return _context.JobApplications
                .Any(a => a.JobId == jobId && a.UserId == userId);
        }

        public List<JobApplication> GetByUserId(int userId)
        {
            return _context.JobApplications
                .Where(a => a.UserId == userId)
                .ToList();
        }
        public List<ApplicantDto> GetApplicantsForJob(int jobId)
        {
            return _context.JobApplications
                .Include(a => a.User)
                .Where(a => a.JobId == jobId)
                .Select(a => new ApplicantDto
                {
                    ApplicationId = a.Id,
                    ApplicantName = a.User.FullName,
                    Email = a.User.Email,
                    AppliedDate = a.AppliedDate,
                    Status = a.Status
                })
                .ToList();
        }
        public JobApplication? GetById(int id)
        {
            return _context.JobApplications.FirstOrDefault(a => a.Id == id);
        }

        public JobApplication Update(JobApplication application)
        {
            _context.JobApplications.Update(application);
            _context.SaveChanges();

            return application;
        }
    }
}