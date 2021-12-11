using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repository;
using DocumentFormat.OpenXml.Wordprocessing;
using DriverLicense.Models;
using DriverLicense.Models.Combined;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class FiltrationController : Controller
    {
        private readonly IRepository<UsersForms> _contextUserForms;

        public FiltrationController(IRepository<UsersForms> contextUserForms)
        {
            _contextUserForms = contextUserForms;
        }

        [HttpPost]
        public IActionResult Index(CombineFormsRadio model)
        {
            try
            {
                IEnumerable<UsersForms> userform = null;

                var context = _contextUserForms.All.ToList();
                var clickedRadioButton = model.ClickedRadioButton.Text;
                var filtrType = model.FiltrType.Type;
                
                if (!ModelState.IsValid)
                    return View("~/Views/Account/AdminPage.cshtml", model);

                if (clickedRadioButton == "Name")
                    userform = context.Where(p => p.FullName.ToLower().Contains(filtrType.ToLower()));
                else if (clickedRadioButton == "Date")
                    userform = context.Where(p => p.Date.ToString().ToLower().Contains(filtrType.ToLower()));
                else if (clickedRadioButton == "Military")
                    userform = context.Where(p => p.MilitaryTicket.ToLower().Contains(filtrType.ToLower()));
                else if (clickedRadioButton == "Category")
                    userform = context.Where(p => p.Category.ToLower().Contains(filtrType.ToLower()));
                else if (clickedRadioButton == "UserID")
                    userform = context.Where(p => p.Users.ID.ToString().ToLower().Contains(filtrType.ToLower()));

                TempData["list"] = JsonConvert.SerializeObject(userform.ToList());

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception e)
            {
                
            }
            
            return RedirectToAction("Index", "Admin");
        }
    }
}