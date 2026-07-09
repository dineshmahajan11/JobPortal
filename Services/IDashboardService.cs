using JobPortal.DTOs;

namespace JobPortal.Services
{
    public interface IDashboardService
    {
        RecruiterDashboardDto GetRecruiterDashboard(int recruiterId);

        JobSeekerDashboardDto GetJobSeekerDashboard(int userId);
    }
}