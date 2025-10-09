using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetFighter.RequestModels;
using NetFighter.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NetFighter.Controllers
{
    [Controller]
    public class AuthApi : Controller
    {
        private readonly IAuthService _authService;

        public AuthApi(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Login() => View();

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            var user = await _authService.Authenticate(username, password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return Redirect("/");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                });

            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("Dashboard")]
        //[Authorize]
        public async Task<IActionResult> Dashboard() => View();

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
