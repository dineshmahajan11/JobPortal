using Microsoft.AspNetCore.Mvc;
using JobPortal.DTOs;
using JobPortal.Services;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateDto dto)
        {
            var user = _userService.CreateUser(dto);

            return Ok(user);
        }
    }
}