using System.Security.Claims;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;

        public ProfileController(
            IUserService userService,
            IWebHostEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
        }

        [HttpPost("upload-resume")]
        public IActionResult UploadResume(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please select a file.");

            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var user = _userService.GetById(userId);

            if (user == null)
                return NotFound("User not found.");

            string uploadsFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "resumes");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName =
                $"{Guid.NewGuid()}_{file.FileName}";

            string filePath =
                Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            user.ResumeUrl = $"uploads/resumes/{fileName}";

            _userService.UpdateUser(user);

            return Ok(new
            {
                Message = "Resume uploaded successfully.",
                ResumeUrl = user.ResumeUrl
            });
        }
    }
}