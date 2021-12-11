using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Data.Models;
using Data.Repository;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class ExportToWordController : Controller
    {
        private readonly IRepository<UsersForms> _contextUser;

        public ExportToWordController(IRepository<UsersForms> contextUser)
        {
            _contextUser = contextUser;
        }
        
        public IActionResult Index(int id)
        {
            var user = _contextUser.All.FirstOrDefault(p => p.ID == id);

            TempData["complete"] = JsonConvert.SerializeObject(user);

            return View("~/Views/WordExport/Template.cshtml", user);
        }
    }
}