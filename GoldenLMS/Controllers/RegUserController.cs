using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoldenLMS.Models;

namespace GoldenLMS.Controllers
{
    public class RegUserController : Controller
    {
        private GoldenLMSEntities db = new GoldenLMSEntities();

        //
        // GET: /RegUser/

        public ActionResult Index()
        {
            return View(db.UserTbls.ToList());
        }

        //
        // GET: /RegUser/Details/5

        public ActionResult Details(int id = 0)
        {
            UserTbl usertbl = db.UserTbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // GET: /RegUser/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RegUser/Create

        [HttpPost]
        public ActionResult Create(UserTbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.UserTbls.Add(usertbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usertbl);
        }

        //
        // GET: /RegUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserTbl usertbl = db.UserTbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // POST: /RegUser/Edit/5

        [HttpPost]
        public ActionResult Edit(UserTbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertbl);
        }

        //
        // GET: /RegUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserTbl usertbl = db.UserTbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // POST: /RegUser/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTbl usertbl = db.UserTbls.Find(id);
            db.UserTbls.Remove(usertbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}