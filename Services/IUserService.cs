
using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User CreateUser(UserCreateDto dto);
        User Register(RegisterDto dto);

        User? Login(LoginDto dto);
        void UpdateUser(User user);

        User? GetById(int id);
    }
}