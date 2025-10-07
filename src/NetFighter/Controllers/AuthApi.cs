using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetFighter.RequestModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using NetFighter.Services;

namespace NetFighter.Controllers
{
    [ApiController]
    public class AuthApi : Controller
    {
        private readonly IAuthService _authService;

        public AuthApi(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Login() => View();

        [HttpPost]
        [Route("/Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(AuthModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            // Authenticate user
            var user = await _authService.Authenticate(login.UserName, login.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(login);
            }

            // Create claims identity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                });

            return new EmptyResult();
        }
        [HttpGet]
        [Route("/Dashboard")]
        [Authorize]
        public async Task<IActionResult> Dashboard() => View();

        [HttpPost]
        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }
}
