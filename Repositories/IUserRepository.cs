using JobPortal.DTOs;
using JobPortal.Models;


namespace JobPortal.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User Add(User user);
        User? GetByEmail(string email);
       

       
    }


}