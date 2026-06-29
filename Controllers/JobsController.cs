using JobPortal.DTOs;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult CreateJob(CreateJobDto dto)
        {
            var job = _jobService.CreateJob(dto);

            return Ok(job);
        }
    }
}