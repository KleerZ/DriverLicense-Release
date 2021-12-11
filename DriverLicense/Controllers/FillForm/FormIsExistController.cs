using Microsoft.AspNetCore.Mvc;

namespace DriverLicense.Controllers.FillForm
{
    public class FormIsExistController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View("~/Views/FillForm/FormIsExist.cshtml");
        }
    }
}