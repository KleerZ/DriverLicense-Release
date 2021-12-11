using System.Linq;
using System.Text.Json;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class UpdateTableController : Controller
    {
        private readonly IRepository<UsersForms> _contextUserForms;

        public UpdateTableController(IRepository<UsersForms> contextUserForms)
        {
            _contextUserForms = contextUserForms;
        }
    
        public IActionResult Index()
        {
            var form = _contextUserForms.All.ToList();
            
            TempData["list"] = JsonConvert.SerializeObject(form);
            
            return RedirectToAction("Index", "Admin");
        }
    }
}