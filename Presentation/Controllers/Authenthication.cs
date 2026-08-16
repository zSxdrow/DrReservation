using Dr.Application.Interfaces.FacadeDesignPattern.UsersFacade;
using Dr.Application.Services.Users.Commands.UserLogins;
using Dr.Application.Services.Users.FacadePattern;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class Authenthication : Controller
    {
        private readonly IUsersFacade _usersFacade;
        public Authenthication(IUsersFacade usersFacade)
        {
            _usersFacade = usersFacade;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            var result = _usersFacade.UserLogin.Execute(new RequestUserLogin
            {
                Password = Password,
                UserName = UserName
            });
            if (result.IsSuccess)
            {
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier , result.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Email , UserName),
                    new Claim(ClaimTypes.Name, result.Data.UserName),
                    new Claim(ClaimTypes.Role, result.Data.Role)
                };
                var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(result);

        }

    }
}
