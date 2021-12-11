using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class SortController : Controller
    {
        private readonly IRepository<UsersForms> _contextUserForm;

        public SortController(IRepository<UsersForms> contextUserForm)
        {
            _contextUserForm = contextUserForm;
        }
        
        public IActionResult SortNumber(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.Users.ID).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.Users.ID).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult SortDate(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.Date).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.Date).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult SortName(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.FullName).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.FullName).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult SortPhone(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.PhoneNumber).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.PhoneNumber).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult SortCategory(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.Category).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.Category).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult SortPassport(int type)
        {
            List<UsersForms> users = null;
            
            if (type == 0)
                users = _contextUserForm.All.OrderBy(s => s.PassportID).ToList();
            else if (type == 1)
                users = _contextUserForm.All.OrderByDescending(s => s.PassportID).ToList();

            TempData["list"] = JsonConvert.SerializeObject(users);

            return RedirectToAction("Index", "Admin");
        }
    }
}