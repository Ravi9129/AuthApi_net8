
using Fantasy.Models;

namespace Fantasy.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        void AddUser(User user);
        void BlacklistToken(string token);
        bool IsTokenBlacklisted(string token);
    }
}
