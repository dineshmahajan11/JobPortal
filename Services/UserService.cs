using AutoMapper;
using JobPortal.DTOs;
using JobPortal.Models;
using JobPortal.Repositories;
using AutoMapper;

namespace JobPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            var user = _userRepository.GetByEmail(dto.Email);

            if (user == null)
            {
                return null;
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return null;
            }

            return user;
        }
        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }


}
