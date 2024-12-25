
using Fantasy.Models;
using Fantasy.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void AddTokenToBlacklist(TokenBlacklist tokenBlacklist)
        {
            _context.TokenBlacklists.Add(tokenBlacklist);
            _context.SaveChanges();
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _context.TokenBlacklists.Any(t => t.Token == token);
        }
    }
}
