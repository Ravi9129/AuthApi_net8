
using Fantasy.Models;
using Fantasy.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fantasy.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private const string SecretKey = "YourSecureAndLongSecretKey12345678901234"; // At least 32 characters
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.Password == password) // Use hashed password check in production
            {
                return user;
            }
            return null;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void BlacklistToken(string token)
        {
            var tokenData = _tokenHandler.ReadJwtToken(token);
            var expirationDate = tokenData.ValidTo;
            var tokenBlacklist = new TokenBlacklist
            {
                Token = token,
                ExpirationDate = expirationDate
            };
            _userRepository.AddTokenToBlacklist(tokenBlacklist);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _userRepository.IsTokenBlacklisted(token);
        }
    }
}
