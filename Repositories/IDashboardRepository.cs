using JobPortal.DTOs;

namespace JobPortal.Repositories
{
    public interface IDashboardRepository
    {
        RecruiterDashboardDto GetRecruiterDashboard(int recruiterId);

        JobSeekerDashboardDto GetJobSeekerDashboard(int userId);
    }
}