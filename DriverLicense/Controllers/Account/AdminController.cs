using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Data.Repository;
using DriverLicense.Models.Combined;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Account
{
    public class AdminController : Controller
    {
        private readonly IRepository<UsersForms> _contextUsers;

        public AdminController(IRepository<UsersForms> contextUsers)
        {
            _contextUsers = contextUsers;
        }

        [Authorize(AuthenticationSchemes = "Cookie")]
        public IActionResult Index()
        {
            var form = _contextUsers.All;

            var json = JsonConvert.SerializeObject(form, 
                new JsonSerializerSettings() 
                { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore 
                });
            
            try
            {
                form = JsonConvert.DeserializeObject<List<UsersForms>>((TempData.Peek("list").ToString()));

                if (form.Count() == 0)
                {
                    form = _contextUsers.All;

                    TempData["list"] = JsonConvert.SerializeObject(form);
                }
            }
            catch
            {
                form = _contextUsers.All;

                TempData["list"] = JsonConvert.SerializeObject(form);
            }
            
            TempData["list"] = JsonConvert.SerializeObject(form);

            ViewBag.Form = form;

            return View("/Views/Account/AdminPage.cshtml");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync("Cookie");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CancelForm(int id)
        {
            // var form = _contextUsers.FindById(id);
            var form = _contextUsers.All.FirstOrDefault(p => p.ID == id);
            _contextUsers.Delete(form);

            TempData["list"] = JsonConvert.SerializeObject(form);

            return RedirectToAction("Index", "Admin");
        }
    }
}