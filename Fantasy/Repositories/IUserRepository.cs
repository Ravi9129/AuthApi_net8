using Fantasy.Models;


namespace Fantasy.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void AddUser(User user);
        void AddTokenToBlacklist(TokenBlacklist tokenBlacklist);
        bool IsTokenBlacklisted(string token);
    }
}
