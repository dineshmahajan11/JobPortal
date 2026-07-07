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
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public IActionResult GetJobs()
        {
            return Ok(_jobService.GetAllJobs());
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public IActionResult CreateJob(CreateJobDto dto)
        {
            var recruiterId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var job = _jobService.CreateJob(dto, recruiterId);

            return Ok(job);
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _jobService.GetJobById(id);

            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, CreateJobDto dto)
        {
            var recruiterId = int.Parse(
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);

            var job = _jobService.UpdateJob(id, dto, recruiterId);

            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var deleted = _jobService.DeleteJob(id);

            if (!deleted)
                return NotFound();

            return Ok("Job deleted successfully.");
        }

        [HttpGet("search")]
        public IActionResult Search(
        string? keyword,
        string? location,
        int page = 1,
        int pageSize = 10)
            {
                return Ok(
                    _jobService.Search(
                        keyword,
                        location,
                        page,
                        pageSize));
            }
    }
}