using JobPortal.DTOs;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Authorize]
        [HttpGet("recruiter")]
        public IActionResult GetRecruiterDashboard()
        {
            var recruiterId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var dashboard =
                _dashboardService.GetRecruiterDashboard(recruiterId);

            return Ok(new ApiResponse<RecruiterDashboardDto>
            {
                Success = true,
                Message = "Recruiter dashboard fetched successfully.",
                Data = dashboard
            });
        }

        [Authorize(Roles = "JobSeeker")]
        [HttpGet("jobseeker")]
        public IActionResult GetJobSeekerDashboard()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var dashboard =
                _dashboardService.GetJobSeekerDashboard(userId);

            return Ok(new ApiResponse<JobSeekerDashboardDto>
            {
                Success = true,
                Message = "Job seeker dashboard fetched successfully.",
                Data = dashboard
            });
        }
    }
}