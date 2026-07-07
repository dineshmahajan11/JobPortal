using JobPortal.Data;
using JobPortal.DTOs;
using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public Job Add(Job job)
        {
            _context.Jobs.Add(job);

            _context.SaveChanges();

            return job;
        }

        public Job? GetById(int id)
        {
            return _context.Jobs.FirstOrDefault(j => j.Id == id);
        }

        public Job Update(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();

            return job;
        }
        public bool Delete(int id)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.Id == id);

            if (job == null)
                return false;

            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return true;
        }

        public List<RecruiterJobDto> GetRecruiterJobs(int recruiterId)
        {
            return _context.Jobs
                .Where(j => j.RecruiterId == recruiterId)
                .Select(j => new RecruiterJobDto
                {
                    Id = j.Id,
                    Title = j.Title,
                    CompanyName = j.CompanyName,
                    Location = j.Location,
                    TotalApplications = j.Applications.Count()
                })
                .ToList();
        }
        public List<Job> Search(
        string? keyword,
        string? location,
        int page,
        int pageSize)
        {
            var query = _context.Jobs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(j => j.Title.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(j => j.Location.Contains(location));
            }

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();


        }
    }
}