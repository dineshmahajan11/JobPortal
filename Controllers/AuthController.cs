using AutoMapper;
using JobPortal.DTOs;
using JobPortal.DTOs.JobPortal.DTOs;
using JobPortal.Helpers;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IUserService userService,
            JwtHelper jwtHelper,
            IMapper mapper,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = _userService.Register(dto);

            var userDto = _mapper.Map<UserDto>(user);

            _logger.LogInformation(
                "New user registered with email {Email}",
                user.Email);

            return StatusCode(StatusCodes.Status201Created,
                new ApiResponse<UserDto>
                {
                    Success = true,
                    Message = "User registered successfully.",
                    Data = userDto
                });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userService.Login(dto);

            if (user == null)
            {
                _logger.LogWarning(
                    "Failed login attempt for email {Email}",
                    dto.Email);

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

            _logger.LogInformation(
                "User {Email} logged in successfully",
                user.Email);

            return Ok(new ApiResponse<LoginResponseDto>
            {
                Success = true,
                Message = "Login successful.",
                Data = response
            });
        }
    }
}