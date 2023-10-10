using BookStore.Mvc.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string? returnPage)
        {
            ViewBag.ReturnUrl = returnPage;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? returnPage)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (!string.IsNullOrEmpty(returnPage) && Url.IsLocalUrl(returnPage))
                    {
                        return Redirect(returnPage);
                    }
                    return Redirect("/");

                }
                ModelState.AddModelError("login", "Kullanıcı adı ya da şifre yanlış!");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
