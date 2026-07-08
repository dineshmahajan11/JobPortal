using JobPortal.DTOs;
using JobPortal.DTOs.JobPortal.DTOs;
using JobPortal.Helpers;
using JobPortal.Models;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService,JwtHelper jwtHelper,IMapper mapper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            try
            {
                var user = _userService.Register(dto);

                return Ok(new ApiResponse<User>
                {
                    Success = true,
                    Message = "User registered successfully.",
                    Data = user
                });
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
                return Unauthorized(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid email or password.",
                    Data = null
                });
            }

            var token = _jwtHelper.GenerateToken(user);

            var response = new LoginResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };

            return Ok(new ApiResponse<LoginResponseDto>
            {
                Success = true,
                Message = "Login successful.",
                Data = response
            });
        }
    }


}
