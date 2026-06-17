using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;

namespace JobPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User CreateUser(UserCreateDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = "JobSeeker"
            };

            return _userRepository.Add(user);
        }

        public User Register(RegisterDto dto)
        {
            var existingUser = _userRepository.GetByEmail(dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "JobSeeker"
            };

            return _userRepository.Add(user);
        }

        public User? Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }
    }


}
