using GoldenLMS.Filters;
using GoldenLMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace GoldenLMS.Controllers
{
   
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private GoldenLMSEntities db = new GoldenLMSEntities();

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(UserTbl usertbl, string returnUrl)
        {
            List<UserTbl> lstUser = db.UserTbls.ToList();
            foreach (var usr in lstUser)
            {
                string um = usr.Name;
                string pw = usr.Password;

              //if (ModelState.IsValid && WebSecurity.Login(usertbl.Name, usertbl.Password))
              if (ModelState.IsValid )
                {
                    if (um == usertbl.Name && pw ==  usertbl.Password)
                    {
                        Session["UserId"] = usr.Id;
                        Session["Name"] = usr.Name;
                        return RedirectToLocal(returnUrl);
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(usertbl);
        }

         //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            if (Session["UserId"] != null)
            {
                WebSecurity.Logout();
                Session["UserId"] = "";
                return RedirectToAction("Index", "Home");
            }
            else {
                return View();
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("StatusIndex", "Lead");
            }
        }

    }
}
