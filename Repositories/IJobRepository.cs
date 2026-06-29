using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IJobRepository
    {
        List<Job> GetAll();

        Job Add(Job job);
    }
}