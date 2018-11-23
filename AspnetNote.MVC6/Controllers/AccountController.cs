using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => 
                        u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));
                    if(user != null)
                    {
                        // session : stored in web server memory
                        HttpContext.Session.SetInt32("User_Login_Key", user.UserNo);

                        return RedirectToAction("LoginSuccess", "Home");                       
                    }                   
                }
                ModelState.AddModelError(string.Empty, "Invalid User ID or Password");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            // HttpContext.Session.Clear(); all session cleared, used by Admin
            HttpContext.Session.Remove("User_Login_Key");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
