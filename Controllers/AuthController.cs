using Microsoft.AspNetCore.Mvc;
using JobPortal.DTOs;
using JobPortal.Services;
using JobPortal.Helpers;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;


        public AuthController(IUserService userService,JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
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

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userService.Login(dto);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var token = _jwtHelper.GenerateToken(user);

            return Ok(new
            {
                Token = token
            });
        }
    }


}
