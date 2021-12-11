using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Account
{
    public class UserProfile : Controller
    {
        private readonly IRepository<UsersForms> _contextUsersForms;
        private readonly IRepository<Users> _contextUsers;

        public UserProfile(IRepository<UsersForms> contextUsersForms, IRepository<Users> contextUsers)
        {
            _contextUsersForms = contextUsersForms;
            _contextUsers = contextUsers;
        }

        public IActionResult Index()
        {
            CheckUserInfo();

            var id = Convert.ToInt32(User.FindFirst("ID").Value);
            var userpage = _contextUsersForms.All.Where(p => p.Users.ID == id);

            return View("~/Views/Account/UserPage2.cshtml", userpage);
        }

        private void CheckUserInfo()
        {
            var firstName = User.FindFirst("FirstName").Value;
            var lastName = User.FindFirst("LastName").Value;
            var fullname = firstName + " " + lastName;
            var confirmuser = _contextUsersForms.All.FirstOrDefault(p =>
                p.FullName == fullname && p.PhoneNumber == User.FindFirst("PhoneNumber").Value);

            string result;

            if (confirmuser != null)
                result = "Да";
            else
                result = "Нет";

            @ViewBag.Res = result;
        }

        [HttpPost]
        public IActionResult SignOut(bool f)
        {
            HttpContext.SignOutAsync("Cookie");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CancelForm(int id)
        {
            var form = _contextUsersForms.All.FirstOrDefault(p => p.ID == id);
            _contextUsersForms.Delete(form);

            TempData["userform"] = JsonConvert.SerializeObject(form);

            return RedirectToAction("Index", "UserProfile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var user = _contextUsers.FindById(id).Result;
            await _contextUsers.Delete(user);
            await HttpContext.SignOutAsync("Cookie");

            return RedirectToAction("Index", "Home");
        }
    }
}