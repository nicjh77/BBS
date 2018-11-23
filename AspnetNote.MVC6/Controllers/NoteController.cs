using System.Linq;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AspnetNote.MVC6.Controllers
{
    // need to update [Authorize], use Identity, should back to the location where it jumped
    public class NoteController : Controller
    {        
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("User_Login_Key")==null)
            {
                return RedirectToAction("Login", "Account");
            }
            using(var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList();

                // pagenation, search, filter, sort, link, cookie

                return View(list);
            }
        }

        public IActionResult Detail(int NoteNo)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetNoteDbContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.NoteNo.Equals(NoteNo));
                return View(note);
            }
        }
        
        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("User_Login_Key").ToString());

            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);
                    if(db.SaveChanges() > 0)
                    {
                        return Redirect("Index");
                    }                   
                }
                ModelState.AddModelError(string.Empty, "Can not store the content");
            }
            return View(model);
        }

        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("User_Login_Key") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
