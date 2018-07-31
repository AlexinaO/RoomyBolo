using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
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


            return View();
        }
        
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                //enregistre en bdd
            }

            return View();
        }

    }
}
