using JobPortal.Data;
using JobPortal.Models;



namespace JobPortal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}