using Roomy.Data;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;

namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Users/Create
        [HttpGet]
        public ActionResult Create()
        {

            /*List<string> liste = new List<string> { "toto", "titi", "tata" };
            liste.FindAll(delegate (string s)
            {
                return s.Contains("bonjour steve");
            });

            liste.FindAll(s => s.Contains("a"));*/


            //blabla

            //ModelState.Remove("Email");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            /*string req = "SELECT * FROM Users WHERE Lastname = @lastname";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(req, null);
            command.Parameters.AddWithValue("@lastname", model.Lastname);*/

            //ModelState.Remove("Email");
            /*if (model.BirthDate > DateTime.Now.AddYears(-18))
                ModelState.AddModelError("BirthDate", "Trop jeune.");*/

            //if (model.IsMail && string.IsNullOrWhiteSpace(model.Email))
            //    ModelState.AddModelError("Email", "erreur...");

            //var resultat = Extentions.FirstDayOfWeek(model.BirthDate);
            //model.BirthDate.FirstDayOfWeek();


            if (ModelState.IsValid)
            {
                //enregistrer en bdd
                db.Users.Add(model);
                db.SaveChanges();
                ViewData["Message"] = $"Utilisateur {model.Firstname} {model.Lastname} enregistré.";
                //ViewBag.Message = "Utilisateur enregistré.";
                return View(new User());
            }
            
            return View(model);
        }

        public ActionResult List()
        {
            var users = db.Users.Where(x => x.Email.Contains(".com"))
                                .OrderBy(x => x.Lastname);

            /*var users2 = from x in db.Users
                         where x.Email.Contains(".com")
                         orderby x.Lastname
                         select x;*/

            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

    }
}
