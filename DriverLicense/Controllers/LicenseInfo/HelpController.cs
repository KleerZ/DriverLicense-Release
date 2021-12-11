using Microsoft.AspNetCore.Mvc;

namespace DriverLicense.Controllers.LicenseInfo
{
    public class HelpController : Controller
    {
        public IActionResult LicenseInfo()
        {
            return View("~/Views/LicenseInfo/LicenseInfo.cshtml");
        }
    }
}