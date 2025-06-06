using Microsoft.AspNetCore.Identity;
using NetFighter.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
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
    }
}
