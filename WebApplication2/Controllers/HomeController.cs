using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private SubsidiariesEntities1 db = new SubsidiariesEntities1();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      
        
        public ActionResult register()
        {
            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult register([Bind(Include = "UserID,Uniquename,Last_Name,Email,Password,MobileNo")] Registration_dbo registration_dbo)
        {
            if (ModelState.IsValid)
            {
                db.Registration_dbo.Add(registration_dbo);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password", registration_dbo.UserID);
            return View(registration_dbo);
        }

     
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Registration_dbo UserID)
        {
            //if (ModelState.IsValid)  
            //{  
            if (IsValid(UserID.Email, UserID.Password))
            {
                FormsAuthentication.SetAuthCookie(UserID.Email, false);
                return RedirectToAction("register");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(db);
        }

        private bool IsValid(string email, string password)
        {
            throw new NotImplementedException();


        }
    }
}