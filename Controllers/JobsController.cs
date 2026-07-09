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
            var jobs = _jobService.GetAllJobs();

            return Ok(new ApiResponse<List<JobDto>>
            {
                Success = true,
                Message = "Jobs fetched successfully.",
                Data = jobs
            });
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public IActionResult CreateJob(CreateJobDto dto)
        {
            var recruiterId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var job = _jobService.CreateJob(dto, recruiterId);

            return StatusCode(StatusCodes.Status201Created,
                new ApiResponse<JobDto>
                {
                    Success = true,
                    Message = "Job created successfully.",
                    Data = job
                });
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _jobService.GetJobById(id);

            if (job == null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Job not found.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<JobDto>
            {
                Success = true,
                Message = "Job fetched successfully.",
                Data = job
            });
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, CreateJobDto dto)
        {
            var recruiterId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var job = _jobService.UpdateJob(id, dto, recruiterId);

            if (job == null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Job not found.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<JobDto>
            {
                Success = true,
                Message = "Job updated successfully.",
                Data = job
            });
        }

        [Authorize(Roles = "Recruiter")]
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var deleted = _jobService.DeleteJob(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Job not found.",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(
            string? keyword,
            string? location,
            int page = 1,
            int pageSize = 10)
        {
            var result = _jobService.Search(keyword, location, page, pageSize);

            return Ok(new ApiResponse<PagedResultDto<JobDto>>
            {
                Success = true,
                Message = "Jobs fetched successfully.",
                Data = result
            });
        }
    }
}