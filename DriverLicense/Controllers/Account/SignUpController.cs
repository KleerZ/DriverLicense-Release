using Microsoft.AspNetCore.Mvc;

namespace DriverLicense.Controllers.Account
{
    public class SignUpController : Controller
    {
        // GET
        public IActionResult SignUp()
        {
            return View("~/Views/SignIn-SignUp/SignUp.cshtml");
        }
    }
}