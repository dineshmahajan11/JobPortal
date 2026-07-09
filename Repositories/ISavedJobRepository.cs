using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface ISavedJobRepository
    {
        SavedJob Add(SavedJob savedJob);

        bool AlreadySaved(int jobId, int userId);

        List<SavedJob> GetByUserId(int userId);

        bool Remove(int jobId, int userId);
    }
}