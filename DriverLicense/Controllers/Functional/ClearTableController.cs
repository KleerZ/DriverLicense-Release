using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class ClearTableController : Controller
    {
        private readonly IRepository<UsersForms> _contextUsersForms;

        public ClearTableController(IRepository<UsersForms> contextUsersForms)
        {
            _contextUsersForms = contextUsersForms;
        }

        [HttpPost]
        public async Task<IActionResult> ClearTable()
        {
            await _contextUsersForms.Clear();

            var form = _contextUsersForms.All.ToList();
            
            TempData["list"] = JsonConvert.SerializeObject(form);
            
            return RedirectToAction("Index", "Admin");
        }
    }
}