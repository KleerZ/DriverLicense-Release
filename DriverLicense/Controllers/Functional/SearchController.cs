using System;
using System.Collections.Generic;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Data.DataBaseContext;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class SearchController : Controller
    {
        private readonly IRepository<UsersForms> _contextUsers;

        public SearchController(IRepository<UsersForms> contextUsers)
        {
            _contextUsers = contextUsers;
        }

        [HttpPost]
        public IActionResult Index()
        {
            string field = Request.Form["search-input"];
            var userforms = _contextUsers.All.ToList();
            var list = new List<UsersForms>();

            var LowerField = field.ToLower();
            
            foreach (var item in userforms)
            {
                if (item.ID.ToString().Contains(LowerField))
                    list.Add(item);
                else if(item.Date.ToString().Contains(LowerField))
                    list.Add(item);
                else if (item.Category.ToLower().Contains(LowerField))
                    list.Add(item);
                else if(item.FullName.ToLower().Contains(LowerField))
                    list.Add(item);
                else if(item.MilitaryTicket.ToLower().Contains(LowerField))
                    list.Add(item);
                else if(item.PhoneNumber.Contains(LowerField))
                    list.Add(item);
                else if(item.PassportID.ToLower().Contains(LowerField))
                    list.Add(item);
                else if(item.Users.ID.ToString().ToLower().Contains(LowerField))
                    list.Add(item);
            }

            foreach (var item in userforms)
            {
                list.Add(item);
            }

            TempData["list"] = JsonConvert.SerializeObject(list.Distinct());

            return RedirectToAction("Index", "Admin");
        }
    }
}