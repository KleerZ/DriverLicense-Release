using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Repository;
using DriverLicense.Models.Account;
using Microsoft.AspNetCore.Authentication;


namespace DriverLicense.Controllers.Account
{
    public class LoginController : Controller
    {
        private readonly IRepository<Users> _contextUsers;

        public LoginController(IRepository<Users> contextUsers)
        {
            _contextUsers = contextUsers;
        }

        public IActionResult Index()
        {
            return View("~/Views/Account/LoginPage.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var ConfirmUser = _contextUsers.All.FirstOrDefault(p => p.PhoneNumber == model.PhoneNumber &&
                                                                    p.FirstName == model.FirstName &&
                                                                    p.LastName == model.LastName &&
                                                                    p.Password == model.Password &&
                                                                    p.Role == "User");
            
            if (!ModelState.IsValid)
                return View("~/Views/Account/LoginPage.cshtml", model);

            var users = _contextUsers.All.FirstOrDefault(p =>
                p.FirstName == model.FirstName &&
                p.LastName == model.LastName &&
                p.Password == model.Password &&
                p.PhoneNumber == model.PhoneNumber &&
                p.Role == "User");

            if (model != null && ConfirmUser != null)
                await Authenticate(users);
            else
            {
                ModelState.AddModelError("Password", "There is no such employee");
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(Users users)
        {
            var claims = new List<Claim>()
            {
                new Claim("ID", users.ID.ToString(), ClaimValueTypes.Integer),
                new Claim("PhoneNumber", users.PhoneNumber, ClaimValueTypes.String),
                new Claim("FirstName", users.FirstName, ClaimValueTypes.String),
                new Claim("LastName", users.LastName, ClaimValueTypes.String),
                new Claim("Role", users.Role, ClaimValueTypes.String)
            };

            TempData["user"] = users.ID;

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync("Cookie", claimPrincipal);
        }
    }
}