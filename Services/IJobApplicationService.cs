using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJobApplicationService
    {
        JobApplication Apply(ApplyJobDto dto, int userId);

        List<JobApplication> GetMyApplications(int userId);
    }
}