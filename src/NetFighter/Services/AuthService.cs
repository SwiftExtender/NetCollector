using Microsoft.AspNetCore.Identity;
using NetFighter.Models;
using System.Threading.Tasks;
using NetFighter.Data;
using Microsoft.EntityFrameworkCore;

namespace NetFighter.Services
{
        public interface IAuthService
        {
            Task<Users> Authenticate(string username, string password);
        }

        public class AuthService : IAuthService
        {
            private readonly ApplicationDbContext _context;
            private readonly IPasswordHasher<Users> _passwordHasher;

            public AuthService(ApplicationDbContext context, IPasswordHasher<Users> passwordHasher)
            {
                _context = context;
                _passwordHasher = passwordHasher;
            }

            public async Task<Users> Authenticate(string username, string password)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

                if (user == null)
                    return null;

                // Verify password hash
                var result = _passwordHasher.VerifyHashedPassword(
                    user,
                    user.PasswordHash,
                    password
                );

                return result == PasswordVerificationResult.Success ? user : null;
            }

            public Users ConstructUser(string username, string password)
            {
                Users user = new Users() { UserName = username };
                user.PasswordHash = _passwordHasher.HashPassword(user, password);
                return user;
            }
    }
}
