using Roomy.Areas.Backoffice.Models;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Areas.Backoffice.Controllers
{
    public class AuthenticationController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();
        // GET: Backoffice/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationViewModel model)
        {
            if (ModelState.IsValid) {
                var user = db.Users.SingleOrDefault(x => x.Email == model.Login && x.Password == model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Login", "Login/mot de passe incorrect.");
                }
                else
                {
                    Session["USER_BO"] = user;
                    return RedirectToAction("Index", "Dashboard", new { area = "Backoffice" });
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Session.Clear();
            Session.Remove("USER_BO");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}