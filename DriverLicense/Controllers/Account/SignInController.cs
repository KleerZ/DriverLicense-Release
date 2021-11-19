using Microsoft.AspNetCore.Mvc;

namespace DriverLicense.Controllers.Account
{
    public class SignInController : Controller
    {
        // GET
        public IActionResult SignIn()
        {
            return View("~/Views/SignIn-SignUp/SignIn.cshtml");
        }
    }
}