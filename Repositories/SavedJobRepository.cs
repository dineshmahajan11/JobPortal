using JobPortal.Data;
using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class SavedJobRepository : ISavedJobRepository
    {
        private readonly ApplicationDbContext _context;

        public SavedJobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SavedJob Add(SavedJob savedJob)
        {
            _context.SavedJobs.Add(savedJob);
            _context.SaveChanges();

            return savedJob;
        }

        public bool AlreadySaved(int jobId, int userId)
        {
            return _context.SavedJobs
                .Any(s => s.JobId == jobId && s.UserId == userId);
        }

        public List<SavedJob> GetByUserId(int userId)
        {
            return _context.SavedJobs
                .Include(s => s.Job)
                .Where(s => s.UserId == userId)
                .ToList();
        }

        public bool Remove(int jobId, int userId)
        {
            var savedJob = _context.SavedJobs
                .FirstOrDefault(s => s.JobId == jobId && s.UserId == userId);

            if (savedJob == null)
                return false;

            _context.SavedJobs.Remove(savedJob);
            _context.SaveChanges();

            return true;
        }
    }
}