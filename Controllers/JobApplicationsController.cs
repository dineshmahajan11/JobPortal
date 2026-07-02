using System.Security.Claims;
using JobPortal.DTOs;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Authorize(Roles = "JobSeeker")]
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _service;

        public JobApplicationsController(IJobApplicationService service)
        {
            _service = service;
        }

        [HttpPost("apply")]
        public IActionResult Apply(ApplyJobDto dto)
        {
            try
            {
                int userId = int.Parse(
                    User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var application = _service.Apply(dto, userId);

                return Ok(application);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("my")]
        public IActionResult MyApplications()
        {
            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var applications = _service.GetMyApplications(userId);

            return Ok(applications);
        }
    }
}