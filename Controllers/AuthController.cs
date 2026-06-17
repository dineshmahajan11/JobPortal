using Microsoft.AspNetCore.Mvc;
using JobPortal.DTOs;
using JobPortal.Services;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;


    public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            try
            {
                var user = _userService.Register(dto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
