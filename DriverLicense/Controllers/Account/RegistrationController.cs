using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Data.Repository;
using DriverLicense.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DriverLicense.Controllers.Account
{
    public class RegistrationController : Controller
    {
        private readonly IRepository<Users> _contextUsers;
        private Users _users;

        public RegistrationController(IRepository<Users> contextUsers)
        {
            _contextUsers = contextUsers;
        }

        public IActionResult Index()
        {
            return View("~/Views/Account/RegistrationPage.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/RegistrationPage.cshtml", model);

            var users = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Role = "User"
            };

            var ConfirmUser = _contextUsers.All.FirstOrDefault(p => p.FirstName == model.FirstName &&
                                                                    p.LastName == model.LastName &&
                                                                    p.PhoneNumber == model.PhoneNumber &&
                                                                    p.Password == model.Password &&
                                                                    p.Role == "User");

            if (model != null)
                if (ConfirmUser != null)
                    return RedirectToAction("Index", "Registration");
                else
                {
                    await _contextUsers.Add(users);
                    await Authenticate(users);
                }
            else
                return RedirectToAction("Index", "Registration");

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
                new Claim("Role", users.Role, ClaimValueTypes.String),
            };

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);
        }
    }
}