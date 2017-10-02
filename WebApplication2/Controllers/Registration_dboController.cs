using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Registration_dboController : Controller
    {
        private SubsidiariesEntities1 db = new SubsidiariesEntities1();

        // GET: Registration_dbo
        public ActionResult Index()
        {
            var registration_dbo = db.Registration_dbo.Include(r => r.Login);
            return View(registration_dbo.ToList());
        }

        // GET: Registration_dbo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_dbo registration_dbo = db.Registration_dbo.Find(id);
            if (registration_dbo == null)
            {
                return HttpNotFound();
            }
            return View(registration_dbo);
        }

        // GET: Registration_dbo/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password");
            return View();
        }

        // POST: Registration_dbo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Uniquename,Last_Name,Email,Password,MobileNo")] Registration_dbo registration_dbo)
        {
            if (ModelState.IsValid)
            {
                db.Registration_dbo.Add(registration_dbo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password", registration_dbo.UserID);
            return View(registration_dbo);
        }

        // GET: Registration_dbo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_dbo registration_dbo = db.Registration_dbo.Find(id);
            if (registration_dbo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password", registration_dbo.UserID);
            return View(registration_dbo);
        }

        // POST: Registration_dbo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Uniquename,Last_Name,Email,Password,MobileNo")] Registration_dbo registration_dbo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration_dbo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Logins, "UserID", "Password", registration_dbo.UserID);
            return View(registration_dbo);
        }

        // GET: Registration_dbo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_dbo registration_dbo = db.Registration_dbo.Find(id);
            if (registration_dbo == null)
            {
                return HttpNotFound();
            }
            return View(registration_dbo);
        }

        // POST: Registration_dbo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration_dbo registration_dbo = db.Registration_dbo.Find(id);
            db.Registration_dbo.Remove(registration_dbo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
