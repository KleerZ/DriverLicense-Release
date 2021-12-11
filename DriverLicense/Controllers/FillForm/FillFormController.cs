using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Data.Repository;
using DriverLicense.Models.Combined;
using DriverLicense.Models.UsersForms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;

namespace DriverLicense.Controllers.FillForm
{
    public class FillFormController : Controller
    {
        private readonly IRepository<UsersForms> _contextUsersForms;
        private readonly IRepository<Category> _contextCategories;
        private readonly IRepository<Users> _contextUsers;

        public FillFormController(IRepository<UsersForms> contextUsersForms, IRepository<Category> contextCategories, IRepository<Users> contextUsers)
        {
            _contextUsersForms = contextUsersForms;
            _contextCategories = contextCategories;
            _contextUsers = contextUsers;
        }

        [Authorize(AuthenticationSchemes = "Cookie")]
        public async Task<IActionResult> FillForm(CombinedListUserForms model)
        {
            var firstName = User.FindFirst("FirstName").Value;
            var lastName = User.FindFirst("LastName").Value;
            var phoneNumber = User.FindFirst("PhoneNumber").Value;
            var id = Convert.ToInt32(User.FindFirst("ID").Value);
            var confirmuser = _contextUsersForms.All.FirstOrDefault(p => p.Users.ID == id);

            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.PhoneNumber = phoneNumber;


            model.Categories = _contextCategories.All.ToList();
            
            // if (confirmuser != null)
            //     return View("~/Views/FillForm/FormIsExist.cshtml");
            // else
            return View("~/Views/FillForm/FillForm.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(CombinedListUserForms model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/FillForm/FillForm.cshtml", model);

            if (Convert.ToInt32(TempData["edit"]) == 1)
            {
                var id = Convert.ToInt32(User.FindFirst("ID").Value);
                var userform = _contextUsersForms.All.FirstOrDefault(p => p.Users.ID == id);
                
                userform.FullName = model.UsersFormsViewModel.FirstName + " " + model.UsersFormsViewModel.LastName;
                userform.PassportID = model.UsersFormsViewModel.PassportID;
                userform.Category = model.UsersFormsViewModel.Category;
                userform.Date = DateTime.Now;
                userform.MilitaryTicket = model.UsersFormsViewModel.MilitaryTicket;
                userform.PhoneNumber = model.UsersFormsViewModel.PhoneNumber;
                userform.Users.ID = Convert.ToInt32(User.FindFirst("ID").Value);
                userform.Category = model.UsersFormsViewModel.Category;

                await _contextUsersForms.Update(userform);

                return RedirectToAction("Index", "Home");
            }
            
            ClaimsPrincipal currentUser = this.User;
            var userid = Convert.ToInt32(User.FindFirst("Id").Value);
            var user = _contextUsers.All.FirstOrDefault(p => p.ID == userid);
            
            try
            {
                var userform = new UsersForms()
                {
                    FullName = user.FirstName + " " + user.LastName,
                    Date = DateTime.Now,
                    PhoneNumber = user.PhoneNumber,
                    MilitaryTicket = model.UsersFormsViewModel.MilitaryTicket,
                    Category = model.UsersFormsViewModel.Category,
                    PassportID = model.UsersFormsViewModel.PassportID,
                    Users = _contextUsers.All.FirstOrDefault(p => p.ID == Convert.ToInt32(User.FindFirst("ID").Value)),
                    Categories = _contextCategories.All.FirstOrDefault(p => p.Name == model.UsersFormsViewModel.Category)
                };
                
                await _contextUsersForms.Add(userform);
            }
            catch (Exception e)
            {
                
            }

            if (Convert.ToInt32(TempData["edit"]) == 1)
                return RedirectToAction("Index", "UserProfile");

            return RedirectToAction("Index", "Home");
        }
    }
}