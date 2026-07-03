using JobPortal.DTOs;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.Controllers
{
    [Authorize(Roles = "Recruiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IJobApplicationService _applicationService;

        public RecruiterController(
            IJobService jobService,
            IJobApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
        }

        [HttpGet("jobs")]
        public IActionResult MyJobs()
        {
            int recruiterId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var jobs = _jobService.GetRecruiterJobs(recruiterId);

            return Ok(jobs);
        }

        [HttpGet("jobs/{jobId}/applications")]
        public IActionResult GetApplicants(int jobId)
        {
            var applicants = _applicationService.GetApplicantsForJob(jobId);

            return Ok(applicants);
        }
        [HttpPut("applications/{applicationId}/status")]
        public IActionResult UpdateStatus(
    int applicationId,
    UpdateApplicationStatusDto dto)
        {
            var application = _applicationService.UpdateStatus(
                applicationId,
                dto.Status);

            if (application == null)
                return NotFound();

            return Ok(application);
        }
    }
}