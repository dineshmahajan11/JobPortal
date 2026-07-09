using JobPortal.DTOs;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.Controllers
{
    [Authorize(Roles = "JobSeeker")]
    [Route("api/[controller]")]
    [ApiController]
    public class SavedJobsController : ControllerBase
    {
        private readonly ISavedJobService _savedJobService;

        public SavedJobsController(ISavedJobService savedJobService)
        {
            _savedJobService = savedJobService;
        }

        [HttpPost("{jobId}")]
        public IActionResult SaveJob(int jobId)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var saved = _savedJobService.SaveJob(jobId, userId);

            if (!saved)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Job is already saved.",
                    Data = null
                });
            }

            return StatusCode(StatusCodes.Status201Created,
                new ApiResponse<string>
                {
                    Success = true,
                    Message = "Job saved successfully.",
                    Data = null
                });
        }

        [HttpGet]
        public IActionResult GetSavedJobs()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var jobs = _savedJobService.GetSavedJobs(userId);

            return Ok(new ApiResponse<List<JobDto>>
            {
                Success = true,
                Message = "Saved jobs fetched successfully.",
                Data = jobs
            });
        }

        [HttpDelete("{jobId}")]
        public IActionResult RemoveSavedJob(int jobId)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var removed = _savedJobService.RemoveSavedJob(jobId, userId);

            if (!removed)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Saved job not found.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Saved job removed successfully.",
                Data = null
            });
        }
    }
}