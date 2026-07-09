using JobPortal.DTOs;
using JobPortal.Repositories;

namespace JobPortal.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public RecruiterDashboardDto GetRecruiterDashboard(int recruiterId)
        {
            return _dashboardRepository.GetRecruiterDashboard(recruiterId);
        }

        public JobSeekerDashboardDto GetJobSeekerDashboard(int userId)
        {
            return _dashboardRepository.GetJobSeekerDashboard(userId);
        }
    }
}